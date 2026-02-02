using Bullish.Net.Clients;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;

namespace Bullish.Net
{
    internal class BullishAuthenticationProvider : AuthenticationProvider
    {
        private static object _nonceLock = new();
        private static long _lastNonce = 0;

        private static BullishAuthResponse? _authData = null;
        private static DateTime _jwtValidUntil = DateTime.MinValue;

        public override ApiCredentialsType[] SupportedCredentialTypes { get; } = [ApiCredentialsType.Hmac];

        public BullishAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        { }

        private string GenerateNonce()
        {
            lock (_nonceLock)
            {
                var nonce = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                if (nonce <= _lastNonce)
                    nonce = _lastNonce + 1;
                _lastNonce = nonce;
                return nonce.ToString();
            }
        }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
        {
            if (!requestConfig.Authenticated)
                return;

            var timestamp = GetMillisecondTimestamp(apiClient);
            var nonce = GenerateNonce();
            if (requestConfig.Path.Contains("/hmac/login"))
            {
                requestConfig.Headers["BX-TIMESTAMP"] = timestamp;
                requestConfig.Headers["BX-NONCE"] = nonce;
                requestConfig.Headers["BX-PUBLIC-KEY"] = _credentials.Key;
                requestConfig.Headers["BX-SIGNATURE"] = SignHMACSHA256($"{timestamp}{nonce}GET{requestConfig.Path}?{requestConfig.QueryParameters.ToFormData()}", SignOutputType.Hex).ToLower();
                return;
            }
            else
            {
                SetAuthHeaders(requestConfig.Headers);
            }
        }

        public void SetAuthHeaders(IDictionary<string, string> headers)
        {
            headers["Authorization"] = "Bearer " + _authData?.Token;
        }

        public async Task EnsureAuthorizedAsync(BullishEnvironment environment)
        {
            if (_authData?.Token == null || DateTime.UtcNow > _jwtValidUntil)
            {
                var client = new BullishRestClient(o => { o.Environment = environment; o.ApiCredentials = _credentials; });
                var result = await client.ExchangeApi.Account.LoginHmac().ConfigureAwait(false);
                if (!result.Success)
                    throw new Exception("Failed to authenticate");
                _authData = result.Data;
                _jwtValidUntil = DateTime.UtcNow.AddHours(23);
            }
        }
    }
}