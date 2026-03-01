using Bullish.Net.Enums;
using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

namespace Bullish.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class BullishRestClientExchangeApiTrading : IBullishRestClientExchangeApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BullishRestClientExchangeApi _baseClient;
        private readonly ILogger _logger;

        internal BullishRestClientExchangeApiTrading(ILogger logger, BullishRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
            _logger = logger;
        }

        #region Get Orders

        /// <inheritdoc />
        public async Task<WebCallResult<BullishOrder[]>> GetOrdersAsync(string? symbol = null, string? tradingAccountId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("tradingAccountId", tradingAccountId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v2/orders", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishOrder[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Place Order

        /// <inheritdoc />
        public async Task<WebCallResult<BullishOrder>> PlaceOrderAsync(string symbol, BullishTradeSide side, BullishOrderType type, decimal quantity, decimal? price = null, decimal? stopPrice = null, string? clientOrderId = null, BullishTimeInForce? timeInForce = null, string? tradingAccountId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("type", type);
            parameters.AddString("quantity", quantity);
            parameters.AddOptionalString("price", price);
            parameters.AddOptionalString("stopPrice", stopPrice);
            parameters.AddOptional("clientOrderId", clientOrderId);
            parameters.AddOptionalEnum("timeInForce", timeInForce);
            parameters.AddOptional("tradingAccountId", tradingAccountId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v2/orders", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishOrder>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Order

        /// <inheritdoc />
        public async Task<WebCallResult<BullishOrder>> GetOrderAsync(string orderId, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v2/orders/{orderId}", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishOrder>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Order By Client Order Id

        /// <inheritdoc />
        public async Task<WebCallResult<BullishOrder>> GetOrderByClientOrderIdAsync(string clientOrderId, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v2/orders/client-order-id/{clientOrderId}", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishOrder>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Cancel Order

        /// <inheritdoc />
        public async Task<WebCallResult<BullishOrder>> CancelOrderAsync(string orderId, string symbol, string? tradingAccountId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("orderId", orderId);
            parameters.Add("symbol", symbol);
            parameters.AddOptional("tradingAccountId", tradingAccountId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v2/command-cancellations", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishOrder>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Amend Order

        /// <inheritdoc />
        public async Task<WebCallResult<BullishOrder>> AmendOrderAsync(string orderId, string symbol, decimal? quantity = null, decimal? price = null, string? tradingAccountId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("orderId", orderId);
            parameters.Add("symbol", symbol);
            parameters.AddOptionalString("quantity", quantity);
            parameters.AddOptionalString("price", price);
            parameters.AddOptional("tradingAccountId", tradingAccountId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v2/command-amend", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishOrder>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Order History

        /// <inheritdoc />
        public async Task<WebCallResult<BullishOrder[]>> GetOrderHistoryAsync(string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? tradingAccountId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("tradingAccountId", tradingAccountId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v2/history/orders", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync<BullishOrder[]>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}
