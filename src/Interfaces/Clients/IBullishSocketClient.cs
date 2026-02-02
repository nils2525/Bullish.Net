using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Options;
using Bullish.Net.Interfaces.Clients.ExchangeApi;
using CryptoExchange.Net.Interfaces.Clients;

namespace Bullish.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the CryptoCom websocket API
    /// </summary>
    public interface IBullishSocketClient : ISocketClient
    {

        /// <summary>
        /// Exchange API endpoints
        /// </summary>
        public IBullishSocketClientExchangeApi ExchangeApi { get; }

        /// <summary>
        /// Update specific options
        /// </summary>
        /// <param name="options">Options to update. Only specific options are changable after the client has been created</param>
        void SetOptions(UpdateOptions options);

        /// <summary>
        /// Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.
        /// </summary>
        /// <param name="credentials">The credentials to set</param>
        void SetApiCredentials(ApiCredentials credentials);
    }
}
