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
        #region Constructors
        /// <summary>
        /// Creates a Bullish subscription for endpoints that start streaming without an explicit subscribe command.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="channel">The Bullish subscription topic.</param>
        /// <param name="symbol">The market symbol, if this is a symbol subscription.</param>
        /// <param name="handler">The update handler.</param>
        /// <param name="auth">Whether the subscription is authenticated.</param>
        public BullishInstantSubscription(ILogger logger, string channel, string? symbol, Action<DateTime, string?, BullishSubscriptionEvent<T>> handler, bool auth)
            : base(logger, channel, symbol, handler, auth, channel, serverSideUnsubscribe: false)
        { }
        #endregion

        #region Methods
        /// <inheritdoc />
        protected override Query? GetSubQuery(SocketConnection connection)
            => null;

        /// <inheritdoc />
        protected override Query? GetUnsubQuery(SocketConnection connection)
            => null;
        #endregion
    }
}
