using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Bullish.Net.Clients.ExchangeApi;
using Bullish.Net.Interfaces.Clients;
using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Objects.Options;

namespace Bullish.Net.Clients
{
    /// <inheritdoc cref="IBullishRestClient" />
    public class BullishRestClient : BaseRestClient<BullishEnvironment, HMACCredential>, IBullishRestClient
    {
        #region Api clients


        /// <inheritdoc />
        public IBullishRestClientExchangeApi ExchangeApi { get; }


        #endregion

        #region constructor/destructor

        /// <summary>
        /// Create a new instance of the BullishRestClient using provided options
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BullishRestClient(Action<BullishRestOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate)))
        {
        }

        /// <summary>
        /// Create a new instance of the BullishRestClient using provided options
        /// </summary>
        /// <param name="options">Option configuration</param>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="httpClient">Http client for this client</param>
        public BullishRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, IOptions<BullishRestOptions> options) : base(loggerFactory, "Bullish")
        {
            Initialize(options.Value);

            ExchangeApi = AddApiClient(new BullishRestClientExchangeApi(_logger, httpClient, options.Value));
        }

        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BullishRestOptions> optionsDelegate)
        {
            BullishRestOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }
    }
}
