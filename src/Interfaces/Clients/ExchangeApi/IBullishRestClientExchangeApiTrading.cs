using Bullish.Net.Enums;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// Bullish Exchange trading endpoints, placing and managing orders.
    /// </summary>
    public interface IBullishRestClientExchangeApiTrading
    {
        /// <summary>
        /// Create a new order. <para><a href="https://docs.exchange.bullish.com/rest/api/create-order-v-2" /></para>
        /// </summary>
        Task<WebCallResult<BullishCreateOrderResult>> PlaceOrderAsync(string tradingAccountId, string symbol, BullishTradeSide side, BullishOrderType type, decimal quantity, BullishTimeInForce timeInForce, decimal? price = null, decimal? stopPrice = null, string? clientOrderId = null, bool? allowBorrow = null, bool? isMmp = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel an order. <para><a href="https://docs.exchange.bullish.com/rest/api/command" /></para>
        /// </summary>
        Task<WebCallResult<BullishCancelOrderResult>> CancelOrderAsync(string tradingAccountId, string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get current orders. <para><a href="https://docs.exchange.bullish.com/rest/api/get-orders-v-2" /></para>
        /// </summary>
        Task<WebCallResult<BullishOrder[]>> GetOrdersAsync(string tradingAccountId, string? symbol = null, string? clientOrderId = null, BullishTradeSide? side = null, BullishOrderStatus? status = null, CancellationToken ct = default);

        /// <summary>
        /// Get an order by exchange order id. <para><a href="https://docs.exchange.bullish.com/rest/api/get-order-by-id-v-2" /></para>
        /// </summary>
        Task<WebCallResult<BullishOrder>> GetOrderAsync(string tradingAccountId, string orderId, CancellationToken ct = default);

        /// <summary>
        /// Get an order by client order id. <para><a href="https://docs.exchange.bullish.com/rest/api/trade-get-order-by-client-order-id-v-2" /></para>
        /// </summary>
        Task<WebCallResult<BullishOrder>> GetOrderByClientOrderIdAsync(string tradingAccountId, string clientOrderId, CancellationToken ct = default);

        /// <summary>
        /// Get historical orders. <para><a href="https://docs.exchange.bullish.com/rest/api/get-orders-history-v-2" /></para>
        /// </summary>
        Task<WebCallResult<BullishPagedResult<BullishOrder>>> GetOrderHistoryAsync(string tradingAccountId, DateTime? startTime = null, DateTime? endTime = null, string? symbol = null, string? orderId = null, string? clientOrderId = null, BullishTradeSide? side = null, BullishOrderStatus? status = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default);

        /// <summary>
        /// Get current trades. <para><a href="https://docs.exchange.bullish.com/rest/api/get-trades" /></para>
        /// </summary>
        Task<WebCallResult<BullishPagedResult<BullishUserTrade>>> GetTradesAsync(string tradingAccountId, string? symbol = null, string? orderId = null, string? clientOrderId = null, string? otcTradeId = null, string? clientOtcTradeId = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical trades. <para><a href="https://docs.exchange.bullish.com/rest/api/get-trades-history" /></para>
        /// </summary>
        Task<WebCallResult<BullishPagedResult<BullishUserTrade>>> GetTradeHistoryAsync(string tradingAccountId, DateTime? startTime = null, DateTime? endTime = null, string? symbol = null, string? orderId = null, string? tradeId = null, string? clientOrderId = null, string? otcTradeId = null, string? clientOtcTradeId = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default);

    }
}
