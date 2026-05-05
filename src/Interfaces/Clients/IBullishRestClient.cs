using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Options;
using Bullish.Net.Interfaces.Clients.ExchangeApi;
using CryptoExchange.Net.Interfaces.Clients;

namespace Bullish.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bullish Rest API
    /// </summary>
    public interface IBullishRestClient : IRestClient<HMACCredential>
    {

        /// <summary>
        /// Exchange API endpoints
        /// </summary>
        public IBullishRestClientExchangeApi ExchangeApi { get; }
    }
}
