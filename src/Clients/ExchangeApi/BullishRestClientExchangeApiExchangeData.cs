using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

namespace Bullish.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class BullishRestClientExchangeApiExchangeData : IBullishRestClientExchangeApiExchangeData
    {
        private readonly BullishRestClientExchangeApi _baseClient;
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        internal BullishRestClientExchangeApiExchangeData(ILogger logger, BullishRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Server Time

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/time", BullishExchange.RateLimiter.Generic, 1, false);
            var result = await _baseClient.SendAsync<BullishTimestamp>(request, null, ct).ConfigureAwait(false);
            return result.As(result.Data.Timestamp);
        }

        #endregion

        #region Get Symbols

        /// <inheritdoc />
        public async Task<WebCallResult<BullishSymbol[]>> GetSymbolsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/markets", BullishExchange.RateLimiter.Generic, 1, false);
            var result = await _baseClient.SendAsync<BullishSymbol[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BullishAsset[]>> GetAssetsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v1/assets", BullishExchange.RateLimiter.Generic, 1, false);
            var result = await _baseClient.SendAsync<BullishAsset[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        public async Task<WebCallResult<BullishTicker[]>> GetTickersAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "markets/ticker24h", BullishExchange.RateLimiter.Generic, 1, false);
            var result = await _baseClient.SendAsync<BullishTicker[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        public async Task<WebCallResult<BullishTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/markets/{symbol}/tick", BullishExchange.RateLimiter.Generic, 1, false);
            var result = await _baseClient.SendAsync<BullishTicker>(request, null, ct).ConfigureAwait(false);
            return result;
        }
        #endregion

    }
}
