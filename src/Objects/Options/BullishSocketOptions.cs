using CryptoExchange.Net.Objects.Options;

namespace Bullish.Net.Objects.Options
{
    /// <summary>
    /// Options for the CryptoComSocketClient
    /// </summary>
    public class BullishSocketOptions : SocketExchangeOptions<BullishEnvironment>
    {
        /// <summary>
        /// Default options for new clients
        /// </summary>
        internal static BullishSocketOptions Default { get; set; } = new BullishSocketOptions()
        {
            Environment = BullishEnvironment.Live,
            SocketSubscriptionsCombineTarget = 200,
            MaxSocketConnections = 100,
        };

        /// <summary>
        /// ctor
        /// </summary>
        public BullishSocketOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Exchange API options
        /// </summary>
        public SocketApiOptions ExchangeOptions { get; private set; } = new SocketApiOptions();

        internal BullishSocketOptions Set(BullishSocketOptions targetOptions)
        {
            targetOptions = base.Set<BullishSocketOptions>(targetOptions);
            targetOptions.ExchangeOptions = ExchangeOptions.Set(targetOptions.ExchangeOptions);
            return targetOptions;
        }
    }
}
