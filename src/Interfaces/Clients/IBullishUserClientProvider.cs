using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;

namespace Bullish.Net.Interfaces.Clients
{
    /// <summary>
    /// Provider for clients with credentials for specific users
    /// </summary>
    public interface IBullishUserClientProvider : IExchangeService
    {
        /// <summary>
        /// Initialize a client for the specified user identifier. This can be used to initialize a client for a user so ApiCredentials do not need to be passed later.
        /// </summary>
        void InitializeUserClient(string userIdentifier, HMACCredential credentials, BullishEnvironment? environment = null);

        /// <summary>
        /// Reset the cached clients for a user.
        /// </summary>
        void ClearUserClients(string userIdentifier);

        /// <summary>
        /// Get the Rest client for a specific user.
        /// </summary>
        IBullishRestClient GetRestClient(string userIdentifier, HMACCredential? credentials = null, BullishEnvironment? environment = null);

        /// <summary>
        /// Get the Socket client for a specific user.
        /// </summary>
        IBullishSocketClient GetSocketClient(string userIdentifier, HMACCredential? credentials = null, BullishEnvironment? environment = null);
    }
}