using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;

namespace Bullish.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange API endpoints
    /// </summary>
    public interface IBullishRestClientExchangeApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        public IBullishClientExchangeApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        public IBullishRestClientExchangeApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        public IBullishRestClientExchangeApiTrading Trading { get; }
    }
}
