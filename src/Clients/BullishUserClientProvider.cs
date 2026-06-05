using System.Collections.Concurrent;
using Bullish.Net.Clients.ExchangeApi;
using Bullish.Net.Interfaces.Clients;
using Bullish.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bullish.Net.Clients
{
    /// <inheritdoc />
    public class BullishUserClientProvider : IBullishUserClientProvider
    {
        private readonly ConcurrentDictionary<string, IBullishRestClient> _restClients = new();
        private readonly ConcurrentDictionary<string, IBullishSocketClient> _socketClients = new();

        private readonly IOptions<BullishRestOptions> _restOptions;
        private readonly IOptions<BullishSocketOptions> _socketOptions;
        private readonly HttpClient _httpClient;
        private readonly ILoggerFactory? _loggerFactory;

        /// <inheritdoc />
        public string ExchangeName => BullishExchange.ExchangeName;

        /// <summary>
        /// ctor
        /// </summary>
        public BullishUserClientProvider(Action<BullishOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate).Rest), Options.Create(ApplyOptionsDelegate(optionsDelegate).Socket))
        { }

        /// <summary>
        /// ctor
        /// </summary>
        public BullishUserClientProvider(HttpClient? httpClient, ILoggerFactory? loggerFactory, IOptions<BullishRestOptions> restOptions, IOptions<BullishSocketOptions> socketOptions)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.Timeout = restOptions.Value.RequestTimeout;
            _loggerFactory = loggerFactory;
            _restOptions = restOptions;
            _socketOptions = socketOptions;
        }

        /// <inheritdoc />
        public void InitializeUserClient(string userIdentifier, HMACCredential credentials, BullishEnvironment? environment = null)
        {
            CreateRestClient(userIdentifier, credentials, environment);
            CreateSocketClient(userIdentifier, credentials, environment);
        }

        /// <inheritdoc />
        public void ClearUserClients(string userIdentifier)
        {
            _restClients.TryRemove(userIdentifier, out _);
            _socketClients.TryRemove(userIdentifier, out _);
        }

        /// <inheritdoc />
        public async Task LogoutUserClientsAsync(string userIdentifier, CancellationToken ct = default)
        {
            _restClients.TryRemove(userIdentifier, out var restClient);
            _socketClients.TryRemove(userIdentifier, out var socketClient);

            try
            {
                if (restClient != null && !restClient.Disposed)
                {
                    try
                    {
                        await restClient.ExchangeApi.Account.LogoutAsync(ct).ConfigureAwait(false);
                    }
                    catch
                    {
                        // Logout failures should not prevent clearing cached clients.
                    }
                }

                if (socketClient != null && !socketClient.Disposed && socketClient.ExchangeApi is BullishSocketClientExchangeApi socketApi)
                {
                    try
                    {
                        await socketApi.LogoutAsync(ct).ConfigureAwait(false);
                    }
                    catch
                    {
                        // Logout failures should not prevent clearing cached clients.
                    }
                }
            }
            finally
            {
                restClient?.Dispose();
                socketClient?.Dispose();
            }
        }

        /// <inheritdoc />
        public IBullishRestClient GetRestClient(string userIdentifier, HMACCredential? credentials = null, BullishEnvironment? environment = null)
        {
            if (!_restClients.TryGetValue(userIdentifier, out var client) || client.Disposed)
                client = CreateRestClient(userIdentifier, credentials, environment);

            return client;
        }

        /// <inheritdoc />
        public IBullishSocketClient GetSocketClient(string userIdentifier, HMACCredential? credentials = null, BullishEnvironment? environment = null)
        {
            if (!_socketClients.TryGetValue(userIdentifier, out var client) || client.Disposed)
                client = CreateSocketClient(userIdentifier, credentials, environment);

            return client;
        }

        private IBullishRestClient CreateRestClient(string userIdentifier, HMACCredential? credentials, BullishEnvironment? environment)
        {
            var client = new BullishRestClient(_httpClient, _loggerFactory, SetRestEnvironment(environment));
            if (credentials != null)
            {
                client.SetApiCredentials(credentials);
                _restClients[userIdentifier] = client;
            }

            return client;
        }

        private IBullishSocketClient CreateSocketClient(string userIdentifier, HMACCredential? credentials, BullishEnvironment? environment)
        {
            var client = new BullishSocketClient(SetSocketEnvironment(environment), _loggerFactory);
            if (credentials != null)
            {
                client.SetApiCredentials(credentials);
                _socketClients[userIdentifier] = client;
            }

            return client;
        }

        private IOptions<BullishRestOptions> SetRestEnvironment(BullishEnvironment? environment)
        {
            if (environment == null)
                return _restOptions;

            var newRestClientOptions = new BullishRestOptions();
            _restOptions.Value.Set(newRestClientOptions);
            newRestClientOptions.Environment = environment;
            return Options.Create(newRestClientOptions);
        }

        private IOptions<BullishSocketOptions> SetSocketEnvironment(BullishEnvironment? environment)
        {
            if (environment == null)
                return _socketOptions;

            var newSocketClientOptions = new BullishSocketOptions();
            _socketOptions.Value.Set(newSocketClientOptions);
            newSocketClientOptions.Environment = environment;
            return Options.Create(newSocketClientOptions);
        }

        private static T ApplyOptionsDelegate<T>(Action<T>? del) where T : new()
        {
            var opts = new T();
            del?.Invoke(opts);
            return opts;
        }
    }
}
