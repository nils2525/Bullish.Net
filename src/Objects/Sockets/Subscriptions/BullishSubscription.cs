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
        private readonly string _channel;
        private readonly string? _symbol;
        private readonly string? _tradingAccountId;
        private readonly Action<DateTime, string?, BullishSubscriptionEvent<T>> _handler;

        /// <summary>
        /// ctor
        /// </summary>
        public BullishSubscription(ILogger logger, string channel, string? symbol, Action<DateTime, string?, BullishSubscriptionEvent<T>> handler, bool auth, string listenChannel, string? tradingAccountId = null) : base(logger, auth)
        {
            _handler = handler;
            _channel = channel;
            _symbol = symbol;
            _tradingAccountId = tradingAccountId;
            Topic = $"{listenChannel}#{symbol ?? tradingAccountId}";

            MessageRouter = symbol != null ?
                MessageRouter.CreateWithTopicFilter<BullishSubscriptionEvent<T>>(listenChannel, symbol, DoHandleMessage) :
                MessageRouter.CreateWithoutTopicFilter<BullishSubscriptionEvent<T>>(listenChannel, DoHandleMessage);
        }

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
    }
}
