using Bullish.Net.Objects.Internal;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;
using CryptoExchange.Net.Sockets.Default.Routing;

namespace Bullish.Net.Objects.Sockets.Subscriptions
{
    /// <inheritdoc />
    internal class BullishSubscription<T> : Subscription
    {
        #region Fields
        private readonly string _channel;
        private readonly string? _symbol;
        private readonly string? _tradingAccountId;
        private readonly bool _serverSideUnsubscribe;
        private readonly Action<DateTime, string?, BullishSubscriptionEvent<T>> _handler;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a Bullish socket subscription.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="channel">The Bullish subscription topic.</param>
        /// <param name="symbol">The market symbol, if this is a symbol subscription.</param>
        /// <param name="handler">The update handler.</param>
        /// <param name="auth">Whether the subscription is authenticated.</param>
        /// <param name="listenChannel">The data type channel to listen for.</param>
        /// <param name="tradingAccountId">The trading account id, if this is a private data subscription.</param>
        /// <param name="serverSideUnsubscribe">Whether Bullish supports an unsubscribe command for this topic.</param>
        public BullishSubscription(
            ILogger logger,
            string channel,
            string? symbol,
            Action<DateTime, string?, BullishSubscriptionEvent<T>> handler,
            bool auth,
            string listenChannel,
            string? tradingAccountId = null,
            bool serverSideUnsubscribe = false) : base(logger, auth)
        {
            _handler = handler;
            _channel = channel;
            _symbol = symbol;
            _tradingAccountId = tradingAccountId;
            _serverSideUnsubscribe = serverSideUnsubscribe;
            Topic = $"{listenChannel}#{symbol ?? tradingAccountId}";

            MessageRouter = symbol != null ?
                MessageRouter.CreateWithTopicFilter<BullishSubscriptionEvent<T>>(listenChannel, symbol, DoHandleMessage) :
                MessageRouter.CreateWithoutTopicFilter<BullishSubscriptionEvent<T>>(listenChannel, DoHandleMessage);
        }
        #endregion

        #region Methods
        /// <inheritdoc />
        protected override Query? GetSubQuery(SocketConnection connection)
        {
            var parameters = new ParameterCollection
            {
                { "topic", _channel }
            };
            parameters.AddOptional("symbol", _symbol);
            parameters.AddOptional("tradingAccountId", _tradingAccountId);

            return new BullishQuerySubscription(new BullishSocketRequest
            {
                Method = "subscribe",
                Parameters = parameters
            }, Authenticated);
        }

        /// <inheritdoc />
        protected override Query? GetUnsubQuery(SocketConnection connection)
        {
            if (!_serverSideUnsubscribe)
                return null;

            var parameters = new ParameterCollection
            {
                { "topic", _channel }
            };
            parameters.AddOptional("symbol", _symbol);
            parameters.AddOptional("tradingAccountId", _tradingAccountId);

            return new BullishQuerySubscription(new BullishSocketRequest
            {
                Method = "unsubscribe",
                Parameters = parameters
            }, Authenticated);
        }

        /// <inheritdoc />
        public CallResult DoHandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BullishSubscriptionEvent<T> message)
        {
            _handler.Invoke(receiveTime, originalData, message);
            return CallResult.SuccessResult;
        }
        #endregion
    }
}
