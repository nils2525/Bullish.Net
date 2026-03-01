using System.Collections.Concurrent;
using System.Net.WebSockets;
using Bitrue.Net.ExtensionMethods;
using Bullish.Net.Clients.MessageHandlers;
using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Objects.Internal;
using Bullish.Net.Objects.Models;
using Bullish.Net.Objects.Options;
using Bullish.Net.Objects.Sockets;
using Bullish.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;

namespace Bullish.Net.Clients.ExchangeApi
{
    /// <summary>
    /// Client providing access to the CryptoCom Exchange websocket Api
    /// </summary>
    internal partial class BullishSocketClientExchangeApi : SocketApiClient, IBullishSocketClientExchangeApi
    {
        #region fields
        private readonly ConcurrentDictionary<string, string> _unsubscribed = new();
        private readonly ConcurrentDictionary<int, string> _subscribed = new();
        #endregion

        public new BullishSocketOptions ClientOptions => (BullishSocketOptions)base.ClientOptions;

        #region constructor/destructor

        /// <summary>
        /// ctor
        /// </summary>
        internal BullishSocketClientExchangeApi(ILogger logger, BullishSocketOptions options) :
            base(logger, options.Environment.SocketClientAddress!, options, options.ExchangeOptions)
        {
            RateLimiter = BullishExchange.RateLimiter.Generic;
            RegisterPeriodicQuery("pong", TimeSpan.FromMinutes(1), (c) => new BullishPingQuery(false), null);
        }
        #endregion

        #region Subscriptions

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BullishExchange.SerializerContext));

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BullishAuthenticationProvider(credentials);

        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType)
            => new BullishSocketSpotMessageHandler();

        protected override WebSocketParameters GetWebSocketParameters(string address)
        {
            var parameters = base.GetWebSocketParameters(address);

            if (AuthenticationProvider != null)
                ((BullishAuthenticationProvider)AuthenticationProvider!).SetAuthHeaders(parameters.Headers);

            return parameters;
        }

        protected override async Task<CallResult<SocketConnection>> GetSocketConnection(string address, bool authenticated, bool dedicatedRequestConnection, CancellationToken ct, string? topic = null, int individualSubscriptionCount = 1)
        {
            if (authenticated)
                await ((BullishAuthenticationProvider)AuthenticationProvider!).EnsureAuthorizedAsync(ClientOptions.Environment).ConfigureAwait(false);

            return await base.GetSocketConnection(address, authenticated, dedicatedRequestConnection, ct, topic);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BullishTicker>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BullishSubscriptionEvent<BullishTicker>>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Data.PublishedAtTimestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<BullishTicker>(BullishExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(data.Data.Symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BullishSubscription<BullishTicker>(_logger, "tick", symbol, internalHandler, false, "V1TATickerResponse");
            return await SubscribeAsync(BaseAddress.AppendPath($"/trading-api/v1/market-data/tick"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<BullishTrade[]>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BullishSubscriptionEvent<BullishTradeSocketData>>((receiveTime, originalData, data) =>
            {
                DateTime? timestamp = data.Data.Trades.Any() ? data.Data.Trades.Max(c => c.PublishedAtTimestamp) : null;
                if (timestamp != null)
                    UpdateTimeOffset(timestamp.Value);

                onMessage(
                    new DataEvent<BullishTrade[]>(BullishExchange.ExchangeName, data.Data.Trades, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(data.Data.Symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new BullishSubscription<BullishTradeSocketData>(_logger, "anonymousTrades", symbol, internalHandler, false, "V1TAAnonymousTradeUpdate");
            return await SubscribeAsync(BaseAddress.AppendPath("/trading-api/v1/market-data/trades"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, bool bboOnly, Action<DataEvent<BullishOrderBook>> onMessage, CancellationToken ct = default)
        {
            var topic = bboOnly ? "l1Orderbook" : "l2Orderbook";
            var listenChannel = bboOnly ? "V1TALevel1" : "V1TALevel2";

            var internalHandler = new Action<DateTime, string?, BullishSubscriptionEvent<BullishOrderBook>>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Data.Timestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<BullishOrderBook>(BullishExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(data.Data.Symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BullishSubscription<BullishOrderBook>(_logger, topic, symbol, internalHandler, false, listenChannel);
            return SubscribeAsync(BaseAddress.AppendPath("/trading-api/v1/market-data/orderbook"), subscription, ct);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BullishOrderUpdate>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BullishSubscriptionEvent<BullishOrderUpdate>>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Data.Timestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<BullishOrderUpdate>(BullishExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(data.Data.Symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BullishSubscription<BullishOrderUpdate>(_logger, "orders", null, internalHandler, true, "V1TAOrderUpdate");
            return await SubscribeAsync(BaseAddress.AppendPath("/trading-api/v1/private-data"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<BullishUserTrade>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BullishSubscriptionEvent<BullishUserTrade>>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Data.Timestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<BullishUserTrade>(BullishExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(data.Data.Symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BullishSubscription<BullishUserTrade>(_logger, "trades", null, internalHandler, true, "V1TATradeUpdate");
            return await SubscribeAsync(BaseAddress.AppendPath("/trading-api/v1/private-data"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToAssetAccountUpdatesAsync(Action<DataEvent<BullishAssetAccount>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, BullishSubscriptionEvent<BullishAssetAccount>>((receiveTime, originalData, data) =>
            {
                // BullishAssetAccount has no timestamp field, use receive time as fallback
                var timestamp = DateTime.UtcNow;

                onMessage(
                    new DataEvent<BullishAssetAccount>(BullishExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(data.Data.Symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new BullishSubscription<BullishAssetAccount>(_logger, "assetAccounts", null, internalHandler, true, "V1TAAssetAccountUpdate");
            return await SubscribeAsync(BaseAddress.AppendPath("/trading-api/v1/private-data"), subscription, ct).ConfigureAwait(false);
        }
        #endregion

        #region Queries
        #endregion

        /// <inheritdoc />
        protected override Task<Query?> GetAuthenticationRequestAsync(SocketConnection connection)
        {
            throw new NotImplementedException();
            //var authProvider = (BullishAuthenticationProvider)AuthenticationProvider!;
            //var authParams = authProvider.AuthenticateSocket();
            //return Task.FromResult<Query?>(new BullishQuery<BullishSocketAuthResponse>(new("subscribe")
            //{
            //    Channels = ["auth"],
            //    Parameters = authParams
            //}, "auth", false, 1));
        }

        public override async Task UnsubscribeAsync(UpdateSubscription subscription)
        {
            if (_subscribed.TryRemove(subscription.Id, out var topic))
                _unsubscribed.TryAdd(topic, topic);

            await base.UnsubscribeAsync(subscription);
        }

        public override Task<bool> UnsubscribeAsync(int subscriptionId)
        {
            return base.UnsubscribeAsync(subscriptionId);
        }

        protected override async Task<CallResult<UpdateSubscription>> SubscribeAsync(Subscription subscription, CancellationToken ct)
        {
            if (subscription.Topic != null)
                _unsubscribed.TryRemove(subscription.Topic, out _);

            var response = await base.SubscribeAsync(subscription, ct);
            if (response.Success && subscription.Topic != null)
                _subscribed.TryAdd(response.Data.Id, subscription.Topic);

            return response;
        }

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BullishExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);
    }
}
