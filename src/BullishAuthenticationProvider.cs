using System.Collections.Concurrent;
using Bullish.Net.Clients;
using Bullish.Net.Clients.ExchangeApi;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using System.Text.Json;

namespace Bullish.Net
{
    internal class BullishAuthenticationProvider : AuthenticationProvider<HMACCredential>
    {
        // JWTs are valid for 24h server-side. Use a shorter local TTL so cache rot during
        // normal operation is bounded; reconnect-driven refresh (see BullishSocketClientExchangeApi)
        // handles the case where the server invalidates a token earlier than its declared TTL.
        private static readonly TimeSpan JwtTtl = TimeSpan.FromHours(12);

        private static object _nonceLock = new();
        private static long _lastLoginNonce = 0;
        private static long _lastSignedRequestNonce = 0;

        private readonly object _authLock = new();
        private readonly ConcurrentDictionary<IDictionary<string, string>, byte> _trackedSocketHeaders = new(ReferenceEqualityComparer.Instance);
        private readonly SemaphoreSlim _authSemaphore = new(1, 1);

        private BullishAuthResponse? _authData = null;
        private DateTime _jwtValidUntil = DateTime.MinValue;

        public override string Key => ApiCredentials.Key;

        public BullishAuthenticationProvider(HMACCredential credentials) : base(credentials)
        { }

        private string GenerateLoginNonce()
        {
            lock (_nonceLock)
            {
                var nonce = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                if (nonce <= _lastLoginNonce)
                    nonce = _lastLoginNonce + 1;
                _lastLoginNonce = nonce;
                return nonce.ToString();
            }
        }

        private string GenerateSignedRequestNonce()
        {
            lock (_nonceLock)
            {
                var nonce = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 1000;
                if (nonce <= _lastSignedRequestNonce)
                    nonce = _lastSignedRequestNonce + 1;
                _lastSignedRequestNonce = nonce;
                return nonce.ToString();
            }
        }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
        {
            if (!requestConfig.Authenticated)
                return;

            requestConfig.Headers ??= new Dictionary<string, string>();

            var timestamp = GetMillisecondTimestamp(apiClient);
            if (requestConfig.Path.Contains("/hmac/login"))
            {
                var nonce = GenerateLoginNonce();
                requestConfig.Headers["BX-TIMESTAMP"] = timestamp;
                requestConfig.Headers["BX-NONCE"] = nonce;
                requestConfig.Headers["BX-PUBLIC-KEY"] = ApiCredentials.Key;
                var requestPath = new Uri(requestConfig.BaseAddress).AbsolutePath.TrimEnd('/') + requestConfig.Path;
                var signaturePayload = $"{timestamp}{nonce}{requestConfig.Method.Method.ToUpperInvariant()}{requestPath}";
                requestConfig.Headers["BX-SIGNATURE"] = SignHMACSHA256(ApiCredentials, signaturePayload, SignOutputType.Hex).ToLowerInvariant();
                return;
            }

            SetAuthHeaders(requestConfig.Headers);
            if (IsSignedRequest(requestConfig))
                SetSignedRequestHeaders(requestConfig, timestamp);
        }

        private void SetSignedRequestHeaders(RestRequestConfiguration requestConfig, string timestamp)
        {
            var nonce = GenerateSignedRequestNonce();
            var bodyContent = string.Empty;
            if (requestConfig.BodyParameters?.Count > 0)
            {
                bodyContent = JsonSerializer.Serialize(requestConfig.BodyParameters);
                requestConfig.SetBodyContent(bodyContent);
            }

            var requestPath = new Uri(requestConfig.BaseAddress).AbsolutePath.TrimEnd('/') + requestConfig.Path;
            var signaturePayload = $"{timestamp}{nonce}{requestConfig.Method.Method.ToUpperInvariant()}{requestPath}{bodyContent}";
            var hashedPayload = SignSHA256(signaturePayload, SignOutputType.Hex).ToLowerInvariant();
            requestConfig.Headers!["BX-TIMESTAMP"] = timestamp;
            requestConfig.Headers["BX-NONCE"] = nonce;
            requestConfig.Headers["BX-SIGNATURE"] = SignHMACSHA256(ApiCredentials, hashedPayload, SignOutputType.Hex).ToLowerInvariant();
        }

        private static bool IsSignedRequest(RestRequestConfiguration requestConfig)
            => requestConfig.Method == HttpMethod.Post
               && (requestConfig.Path == "/v2/orders" || requestConfig.Path == "/v2/command");

        private static WebCallResult CreateSuccessfulResult()
            => new(null, null, null, TimeSpan.Zero, null, null, null, null, null, null, null);

        private void ClearAuthorizationLocked()
        {
            Volatile.Write(ref _authData, null);
            _jwtValidUntil = DateTime.MinValue;

            foreach (var headers in _trackedSocketHeaders.Keys)
                headers.Remove("Cookie");
        }

        private string? GetAuthToken()
            => Volatile.Read(ref _authData)?.Token;

        private void SetSocketAuthCookie(IDictionary<string, string> headers)
        {
            while (true)
            {
                var token = GetAuthToken();
                if (token == null)
                    headers.Remove("Cookie");
                else
                    headers["Cookie"] = "JWT_COOKIE=" + token;

                if (token == GetAuthToken())
                    return;
            }
        }

        private async Task<WebCallResult> LogoutTokenAsync(BullishEnvironment environment, string token, CancellationToken ct = default)
        {
            var client = new BullishRestClient(o => { o.Environment = environment; });
            return await ((BullishRestClientExchangeApi)client.ExchangeApi).LogoutTokenAsync(token, ct).ConfigureAwait(false);
        }

        public void SetAuthHeaders(IDictionary<string, string> headers)
        {
            var token = GetAuthToken();
            if (token == null)
                headers.Remove("Authorization");
            else
                headers["Authorization"] = "Bearer " + token;
        }

        public void SetSocketAuthHeaders(IDictionary<string, string> headers)
        {
            _trackedSocketHeaders.TryAdd(headers, 0);
            SetSocketAuthCookie(headers);
        }

        public void UntrackSocketHeaders(IDictionary<string, string> headers)
        {
            _trackedSocketHeaders.TryRemove(headers, out _);
        }

        public void ClearAuthorization()
        {
            lock (_authLock)
            {
                ClearAuthorizationLocked();
            }
        }

        /// <summary>
        /// Logs out the currently cached JWT and clears local authorization state on success.
        /// </summary>
        internal async Task<WebCallResult> LogoutAsync(BullishEnvironment environment, CancellationToken ct = default)
        {
            await _authSemaphore.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                var token = GetAuthToken();
                if (string.IsNullOrWhiteSpace(token))
                {
                    ClearAuthorization();
                    return CreateSuccessfulResult();
                }

                var result = await LogoutTokenAsync(environment, token, ct).ConfigureAwait(false);
                if (result.Success)
                    ClearAuthorization();

                return result;
            }
            finally
            {
                _authSemaphore.Release();
            }
        }

        public async Task EnsureAuthorizedAsync(BullishEnvironment environment, bool forceRefresh = false)
        {
            await _authSemaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                string? previousToken;
                lock (_authLock)
                {
                    var currentAuthData = Volatile.Read(ref _authData);
                    if (!forceRefresh && currentAuthData?.Token != null && DateTime.UtcNow <= _jwtValidUntil)
                        return;

                    previousToken = currentAuthData?.Token;
                    ClearAuthorizationLocked();
                }

                if (!string.IsNullOrWhiteSpace(previousToken))
                {
                    try
                    {
                        await LogoutTokenAsync(environment, previousToken).ConfigureAwait(false);
                    }
                    catch
                    {
                        // A stale token should not prevent obtaining the replacement token.
                    }
                }

                var client = new BullishRestClient(o => { o.Environment = environment; o.ApiCredentials = ApiCredentials; });
                var result = await client.ExchangeApi.Account.LoginHmac().ConfigureAwait(false);
                if (!result.Success)
                    throw new Exception($"Failed to authenticate: {result.Error}");

                lock (_authLock)
                {
                    Volatile.Write(ref _authData, result.Data);
                    _jwtValidUntil = DateTime.UtcNow.Add(JwtTtl);

                    var cookieValue = "JWT_COOKIE=" + result.Data.Token;
                    foreach (var headers in _trackedSocketHeaders.Keys)
                        headers["Cookie"] = cookieValue;
                }
            }
            finally
            {
                _authSemaphore.Release();
            }
        }
    }
}
