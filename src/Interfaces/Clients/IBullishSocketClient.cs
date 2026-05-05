using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Options;
using Bullish.Net.Interfaces.Clients.ExchangeApi;
using CryptoExchange.Net.Interfaces.Clients;

namespace Bullish.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bullish websocket API
    /// </summary>
    public interface IBullishSocketClient : ISocketClient<HMACCredential>
    {

        /// <summary>
        /// Exchange API endpoints
        /// </summary>
        public IBullishSocketClientExchangeApi ExchangeApi { get; }
    }
}
