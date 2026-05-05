using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Enums;
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

        /// <inheritdoc />
        public Task<WebCallResult<BullishCreateOrderResult>> PlaceOrderAsync(string tradingAccountId, string symbol, BullishTradeSide side, BullishOrderType type, decimal quantity, BullishTimeInForce timeInForce, decimal? price = null, decimal? stopPrice = null, string? clientOrderId = null, bool? allowBorrow = null, bool? isMmp = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "commandType", "V3CreateOrder" },
                { "symbol", symbol },
                { "tradingAccountId", tradingAccountId }
            };
            parameters.AddString("quantity", quantity);
            parameters.AddEnum("type", type);
            parameters.AddEnum("side", side);
            parameters.AddEnum("timeInForce", timeInForce);
            parameters.AddOptionalString("price", price);
            parameters.AddOptionalString("stopPrice", stopPrice);
            parameters.AddOptional("clientOrderId", clientOrderId);
            parameters.AddOptional("allowBorrow", allowBorrow);
            parameters.AddOptional("isMMP", isMmp);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v2/orders", BullishExchange.RateLimiter.Generic, 1, true, parameterPosition: HttpMethodParameterPosition.InBody);
            return _baseClient.SendAsync<BullishCreateOrderResult>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<WebCallResult<BullishCancelOrderResult>> CancelOrderAsync(string tradingAccountId, string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null)
                throw new ArgumentException("Either orderId or clientOrderId must be provided");

            var parameters = new ParameterCollection
            {
                { "commandType", "V3CancelOrder" },
                { "tradingAccountId", tradingAccountId },
                { "symbol", symbol }
            };
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOrderId", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v2/command", BullishExchange.RateLimiter.Generic, 1, true, parameterPosition: HttpMethodParameterPosition.InBody);
            return _baseClient.SendAsync<BullishCancelOrderResult>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<WebCallResult<BullishOrder[]>> GetOrdersAsync(string tradingAccountId, string? symbol = null, string? clientOrderId = null, BullishTradeSide? side = null, BullishOrderStatus? status = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "tradingAccountId", tradingAccountId }
            };
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("clientOrderId", clientOrderId);
            parameters.AddOptionalEnum("side", side);
            parameters.AddOptionalEnum("status", status);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v2/orders", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishOrder[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<WebCallResult<BullishOrder>> GetOrderAsync(string tradingAccountId, string orderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "tradingAccountId", tradingAccountId }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v2/orders/{orderId}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishOrder>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<WebCallResult<BullishOrder>> GetOrderByClientOrderIdAsync(string tradingAccountId, string clientOrderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "tradingAccountId", tradingAccountId }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v2/orders/client-order-id/{clientOrderId}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishOrder>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<WebCallResult<BullishOrder[]>> GetOrderHistoryAsync(string tradingAccountId, DateTime? startTime = null, DateTime? endTime = null, string? symbol = null, string? orderId = null, string? clientOrderId = null, BullishTradeSide? side = null, BullishOrderStatus? status = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "tradingAccountId", tradingAccountId }
            };
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOrderId", clientOrderId);
            parameters.AddOptionalEnum("side", side);
            parameters.AddOptionalEnum("status", status);
            parameters.AddOptional("createdAtDatetime[gte]", startTime == null ? null : BullishParameterFormats.FormatDateTime(startTime.Value));
            parameters.AddOptional("createdAtDatetime[lte]", endTime == null ? null : BullishParameterFormats.FormatDateTime(endTime.Value));

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v2/history/orders", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishOrder[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<WebCallResult<BullishUserTrade[]>> GetTradesAsync(string tradingAccountId, string? symbol = null, string? orderId = null, string? clientOrderId = null, string? otcTradeId = null, string? clientOtcTradeId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "tradingAccountId", tradingAccountId }
            };
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOrderId", clientOrderId);
            parameters.AddOptional("otcTradeId", otcTradeId);
            parameters.AddOptional("clientOtcTradeId", clientOtcTradeId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/trades", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishUserTrade[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<WebCallResult<BullishUserTrade[]>> GetTradeHistoryAsync(string tradingAccountId, DateTime? startTime = null, DateTime? endTime = null, string? symbol = null, string? orderId = null, string? tradeId = null, string? clientOrderId = null, string? otcTradeId = null, string? clientOtcTradeId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "tradingAccountId", tradingAccountId }
            };
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("tradeId", tradeId);
            parameters.AddOptional("clientOrderId", clientOrderId);
            parameters.AddOptional("createdAtDatetime[gte]", startTime == null ? null : BullishParameterFormats.FormatDateTime(startTime.Value));
            parameters.AddOptional("createdAtDatetime[lte]", endTime == null ? null : BullishParameterFormats.FormatDateTime(endTime.Value));
            parameters.AddOptional("otcTradeId", otcTradeId);
            parameters.AddOptional("clientOtcTradeId", clientOtcTradeId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/history/trades", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishUserTrade[]>(request, parameters, ct);
        }

    }
}
