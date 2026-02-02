using Bullish.Net.Objects.Internal;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;

namespace Bullish.Net.Objects.Sockets.Subscriptions
{
    /// <inheritdoc />
    internal class BullishInstantSubscription<T> : BullishSubscription<T>
    {
        public BullishInstantSubscription(ILogger logger, string channel, string? symbol, Action<DateTime, string?, BullishSubscriptionEvent<T>> handler, bool auth)
            : base(logger, channel, symbol, handler, auth, channel)
        { }

        protected override Query? GetSubQuery(SocketConnection connection)
            => null;

        protected override Query? GetUnsubQuery(SocketConnection connection)
            => null;
    }
}
