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
        /// Get open orders
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="tradingAccountId">The trading account id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishOrder[]>> GetOrdersAsync(string? symbol = null, string? tradingAccountId = null, CancellationToken ct = default);

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="side">The trade side</param>
        /// <param name="type">The order type</param>
        /// <param name="quantity">The quantity</param>
        /// <param name="price">The price</param>
        /// <param name="stopPrice">The stop price</param>
        /// <param name="clientOrderId">The client order id</param>
        /// <param name="timeInForce">The time in force</param>
        /// <param name="tradingAccountId">The trading account id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishOrder>> PlaceOrderAsync(string symbol, BullishTradeSide side, BullishOrderType type, decimal quantity, decimal? price = null, decimal? stopPrice = null, string? clientOrderId = null, BullishTimeInForce? timeInForce = null, string? tradingAccountId = null, CancellationToken ct = default);

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="orderId">The order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishOrder>> GetOrderAsync(string orderId, CancellationToken ct = default);

        /// <summary>
        /// Get order by client order id
        /// </summary>
        /// <param name="clientOrderId">The client order id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishOrder>> GetOrderByClientOrderIdAsync(string clientOrderId, CancellationToken ct = default);

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="orderId">The order id</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="tradingAccountId">The trading account id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishOrder>> CancelOrderAsync(string orderId, string symbol, string? tradingAccountId = null, CancellationToken ct = default);

        /// <summary>
        /// Amend an order
        /// </summary>
        /// <param name="orderId">The order id</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="quantity">The new quantity</param>
        /// <param name="price">The new price</param>
        /// <param name="tradingAccountId">The trading account id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishOrder>> AmendOrderAsync(string orderId, string symbol, decimal? quantity = null, decimal? price = null, string? tradingAccountId = null, CancellationToken ct = default);

        /// <summary>
        /// Get order history
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="tradingAccountId">The trading account id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishOrder[]>> GetOrderHistoryAsync(string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? tradingAccountId = null, CancellationToken ct = default);
    }
}
