using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class BullishRestClientExchangeApiAccount : IBullishClientExchangeApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BullishRestClientExchangeApi _baseClient;

        internal BullishRestClientExchangeApiAccount(BullishRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
        }

        public Task<WebCallResult<BullishAuthResponse>> LoginHmac(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/users/hmac/login", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishAuthResponse>(request, null, ct);
        }
    }
}
