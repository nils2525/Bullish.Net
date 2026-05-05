using Bullish.Net.Clients;
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
        private static object _nonceLock = new();
        private static long _lastLoginNonce = 0;
        private static long _lastSignedRequestNonce = 0;

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

        public void SetAuthHeaders(IDictionary<string, string> headers)
        {
            headers["Authorization"] = "Bearer " + _authData?.Token;
        }

        public void SetSocketAuthHeaders(IDictionary<string, string> headers)
        {
            if (_authData?.Token != null)
                headers["Cookie"] = "JWT_COOKIE=" + _authData.Token;
        }

        public void ClearAuthorization()
        {
            _authData = null;
            _jwtValidUntil = DateTime.MinValue;
        }

        public async Task EnsureAuthorizedAsync(BullishEnvironment environment)
        {
            if (_authData?.Token == null || DateTime.UtcNow > _jwtValidUntil)
            {
                var client = new BullishRestClient(o => { o.Environment = environment; o.ApiCredentials = ApiCredentials; });
                var result = await client.ExchangeApi.Account.LoginHmac().ConfigureAwait(false);
                if (!result.Success)
                    throw new Exception($"Failed to authenticate: {result.Error}");
                _authData = result.Data;
                _jwtValidUntil = DateTime.UtcNow.AddHours(23);
            }
        }
    }
}