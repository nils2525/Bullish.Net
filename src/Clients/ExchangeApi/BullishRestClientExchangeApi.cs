using Bullish.Net.Clients.MessageHandlers;
using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;

namespace Bullish.Net.Clients.ExchangeApi
{
    /// <inheritdoc cref="IBullishRestClientExchangeApi" />
    internal partial class BullishRestClientExchangeApi : RestApiClient<BullishEnvironment, BullishAuthenticationProvider, HMACCredential>, IBullishRestClientExchangeApi
    {
        #region Fields
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        #endregion

        #region Api clients
        /// <inheritdoc />
        public IBullishClientExchangeApiAccount Account { get; }
        /// <inheritdoc />
        public IBullishRestClientExchangeApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBullishRestClientExchangeApiTrading Trading { get; }
        /// <inheritdoc />
        public string ExchangeName => "Bullish";
        /// <inheritdoc />
        protected override IRestMessageHandler MessageHandler { get; } = new BullishRestMessageHandler();
        #endregion

        #region constructor/destructor
        internal BullishRestClientExchangeApi(ILoggerFactory? loggerFactory, HttpClient? httpClient, BullishRestOptions options)
            : base(loggerFactory, BullishExchange.ExchangeName, httpClient, options.Environment.RestClientAddress.AppendPath("trading-api"), options, options.ExchangeOptions)
        {
            Account = new BullishRestClientExchangeApiAccount(this);
            ExchangeData = new BullishRestClientExchangeApiExchangeData(_logger, this);
            Trading = new BullishRestClientExchangeApiTrading(_logger, this);
        }
        #endregion

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BullishExchange.SerializerContext));

        /// <inheritdoc />
        protected override BullishAuthenticationProvider CreateAuthenticationProvider(HMACCredential credentials)
            => new BullishAuthenticationProvider(credentials);


        internal Task<HttpResult<T>> SendAsync<T>(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
            => SendToAddressAsync<T>(BaseAddress, definition, parameters, cancellationToken, weight);

        internal async Task<HttpResult> SendAsync(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null)
        {
            var result = await SendToAddressAsync<object>(BaseAddress, definition, parameters, cancellationToken, weight).ConfigureAwait(false);
            return result.AsDataless();
        }

        /// <summary>
        /// Send a request with explicit additional headers.
        /// </summary>
        internal async Task<HttpResult> SendAsync(RequestDefinition definition, Parameters? parameters, Dictionary<string, string>? additionalHeaders, CancellationToken cancellationToken, int? weight = null)
        {
            definition.BaseAddress = BaseAddress;
            var result = await base.SendAsync<object>(definition, parameters, cancellationToken, additionalHeaders, weight).ConfigureAwait(false);
            return result.AsDataless();
        }

        /// <summary>
        /// Logout the specified JWT without using the cached authentication provider token.
        /// </summary>
        internal Task<HttpResult> LogoutTokenAsync(string token, CancellationToken cancellationToken = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/users/logout", BullishExchange.RateLimiter.Generic, 1, false);
            return SendAsync(request, null, new Dictionary<string, string>
            {
                { "Authorization", "Bearer " + token }
            }, cancellationToken);
        }

        internal async Task<HttpResult<T>> SendToAddressAsync<T>(string baseAddress, RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            if (definition.Authenticated && definition.Path != "/v1/users/hmac/login" && AuthenticationProvider != null)
                await AuthenticationProvider!.EnsureAuthorizedAsync(ClientOptions.Environment).ConfigureAwait(false);

            definition.BaseAddress = baseAddress;
            var result = await base.SendAsync<T>(definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            if (!result.Success)
                return result.As<T>(default);

            return result;
        }

        /// <inheritdoc />
        protected override Task<HttpResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BullishExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);
    }
}
