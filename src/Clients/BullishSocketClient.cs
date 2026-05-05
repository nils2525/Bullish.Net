using Bullish.Net.Clients.ExchangeApi;
using Bullish.Net.Interfaces.Clients;
using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bullish.Net.Clients
{
    /// <inheritdoc cref="IBullishSocketClient" />
    public class BullishSocketClient : BaseSocketClient<BullishEnvironment, HMACCredential>, IBullishSocketClient
    {
        #region fields
        #endregion

        #region Api clients


        /// <inheritdoc />
        public IBullishSocketClientExchangeApi ExchangeApi { get; }


        #endregion

        #region constructor/destructor

        /// <summary>
        /// Create a new instance of BullishSocketClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BullishSocketClient(Action<BullishSocketOptions>? optionsDelegate = null)
            : this(Options.Create(ApplyOptionsDelegate(optionsDelegate)), null)
        {
        }

        /// <summary>
        /// Create a new instance of BullishSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="options">Option configuration</param>
        public BullishSocketClient(IOptions<BullishSocketOptions> options, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Bullish")
        {
            Initialize(options.Value);

            ExchangeApi = AddApiClient(new BullishSocketClientExchangeApi(_logger, options.Value));
        }
        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BullishSocketOptions> optionsDelegate)
        {
            BullishSocketOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }
    }
}
