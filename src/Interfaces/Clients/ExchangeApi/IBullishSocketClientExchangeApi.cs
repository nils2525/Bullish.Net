using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;

namespace Bullish.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// Bullish Exchange streams
    /// </summary>
    public interface IBullishSocketClientExchangeApi : ISocketApiClient, IDisposable
    {
        /// <summary>
        /// Subscribe to ticker updates
        /// <para><a href="https://docs.exchange.bullish.com/websocket/public/market-data/ticks" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BullishTicker>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates
        /// <para><a href="https://docs.exchange.bullish.com/websocket/public/market-data/trades" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BullishTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates
        /// <para><a href="https://docs.exchange.bullish.com/websocket/public/market-data/orderbook" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, bool bboOnly, Action<DataEvent<BullishOrderBook>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to asset account updates
        /// <para><a href="https://docs.exchange.bullish.com/websocket/private/private-data#operation-receive-receive-assetAccounts" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToAssetAccountUpdatesAsync(string tradingAccountId, Action<DataEvent<BullishAccountAsset[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order updates
        /// <para><a href="https://docs.exchange.bullish.com/websocket/private/private-data#operation-receive-receive-orders" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(string tradingAccountId, Action<DataEvent<BullishOrder[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade updates
        /// <para><a href="https://docs.exchange.bullish.com/websocket/private/private-data#operation-receive-receive-trades" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(string tradingAccountId, Action<DataEvent<BullishUserTrade[]>> onMessage, CancellationToken ct = default);
    }
}
