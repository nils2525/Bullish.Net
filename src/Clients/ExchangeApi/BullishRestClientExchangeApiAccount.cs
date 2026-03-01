using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

namespace Bullish.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class BullishRestClientExchangeApiAccount : IBullishClientExchangeApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BullishRestClientExchangeApi _baseClient;
        private readonly ILogger _logger;

        internal BullishRestClientExchangeApiAccount(ILogger logger, BullishRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
            _logger = logger;
        }

        #region Login

        /// <inheritdoc />
        public Task<WebCallResult<BullishAuthResponse>> LoginHmac(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/users/hmac/login", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishAuthResponse>(request, null, ct);
        }

        #endregion

        #region Get Nonce

        /// <inheritdoc />
        public async Task<WebCallResult<BullishNonce>> GetNonceAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/nonce", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishNonce>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Asset Accounts

        /// <inheritdoc />
        public async Task<WebCallResult<BullishAssetAccount[]>> GetAssetAccountsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/accounts/asset", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishAssetAccount[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Asset Account

        /// <inheritdoc />
        public async Task<WebCallResult<BullishAssetAccount>> GetAssetAccountAsync(string symbol, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/accounts/asset/{symbol}", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishAssetAccount>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Trading Accounts

        /// <inheritdoc />
        public async Task<WebCallResult<BullishTradingAccount[]>> GetTradingAccountsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/accounts/trading-accounts", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishTradingAccount[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Trading Account

        /// <inheritdoc />
        public async Task<WebCallResult<BullishTradingAccount>> GetTradingAccountAsync(string tradingAccountId, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/accounts/trading-accounts/{tradingAccountId}", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishTradingAccount>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get User Trades

        /// <inheritdoc />
        public async Task<WebCallResult<BullishUserTrade[]>> GetUserTradesAsync(string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/trades", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishUserTrade[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get User Trade

        /// <inheritdoc />
        public async Task<WebCallResult<BullishUserTrade>> GetUserTradeAsync(string tradeId, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/trades/{tradeId}", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishUserTrade>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get User Trade History

        /// <inheritdoc />
        public async Task<WebCallResult<BullishUserTrade[]>> GetUserTradeHistoryAsync(string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/history/trades", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishUserTrade[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Logout

        /// <inheritdoc />
        public async Task<WebCallResult<object>> LogoutAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/users/logout", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<object>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion
    }
}
