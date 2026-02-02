using CryptoExchange.Net.Objects.Options;

namespace Bullish.Net.Objects.Options
{
    /// <summary>
    /// Options for the CryptoComRestClient
    /// </summary>
    public class BullishRestOptions : RestExchangeOptions<BullishEnvironment>
    {
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Default options for new clients
        /// </summary>
        internal static BullishRestOptions Default { get; set; } = new BullishRestOptions()
        {
            Environment = BullishEnvironment.Live,
            AutoTimestamp = true
        };

        /// <summary>
        /// ctor
        /// </summary>
        public BullishRestOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Exchange API options
        /// </summary>
        public RestApiOptions ExchangeOptions { get; private set; } = new RestApiOptions();

        internal BullishRestOptions Set(BullishRestOptions targetOptions)
        {
            targetOptions = base.Set<BullishRestOptions>(targetOptions);
            targetOptions.ExchangeOptions = ExchangeOptions.Set(targetOptions.ExchangeOptions);
            targetOptions.ReceiveWindow = ReceiveWindow;
            return targetOptions;
        }
    }
}
