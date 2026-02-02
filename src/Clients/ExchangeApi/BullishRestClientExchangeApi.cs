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
    internal partial class BullishRestClientExchangeApi : RestApiClient, IBullishRestClientExchangeApi
    {
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
        internal BullishRestClientExchangeApi(ILogger logger, HttpClient? httpClient, BullishRestOptions options)
            : base(logger, httpClient, options.Environment.RestClientAddress.AppendPath("trading-api"), options, options.ExchangeOptions)
        {
            Account = new BullishRestClientExchangeApiAccount(this);
            ExchangeData = new BullishRestClientExchangeApiExchangeData(logger, this);
            Trading = new BullishRestClientExchangeApiTrading(logger, this);
        }
        #endregion

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BullishExchange.SerializerContext));

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BullishAuthenticationProvider(credentials);


        internal Task<WebCallResult<T>> SendAsync<T>(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
            => SendToAddressAsync<T>(BaseAddress, definition, parameters, cancellationToken, weight);

        internal async Task<WebCallResult<T>> SendToAddressAsync<T>(string baseAddress, RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            var result = await base.SendAsync<T>(baseAddress, definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            if (!result)
                return result.As<T>(default);

            return result;
        }

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BullishExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);
    }
}
