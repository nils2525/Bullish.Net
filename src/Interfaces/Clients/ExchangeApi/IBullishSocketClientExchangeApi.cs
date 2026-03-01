using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;

namespace Bullish.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange streams
    /// </summary>
    public interface IBullishSocketClientExchangeApi : ISocketApiClient, IDisposable
    {
        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://api.exchange.bullish.com/docs/api/rest/trading-api/v2/#overview--anonymous-market-data-price-tick-unauthenticated" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BullishTicker>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates
        /// <para><a href="https://api.exchange.bullish.com/docs/api/rest/trading-api/v2/#overview--unified-anonymous-trades-websocket-unauthenticated" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BullishTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to candle updates
        /// <para><a href="https://api.exchange.bullish.com/docs/api/rest/trading-api/v2/#overview--multi-orderbook-websocket-unauthenticated" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, bool bboOnly, Action<DataEvent<BullishOrderBook>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order updates (authenticated)
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BullishOrderUpdate>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade updates (authenticated)
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<BullishUserTrade>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to asset account balance updates (authenticated)
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToAssetAccountUpdatesAsync(Action<DataEvent<BullishAssetAccount>> onMessage, CancellationToken ct = default);
    }
}
