using Bullish.Net.Interfaces.Clients.ExchangeApi;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

namespace Bullish.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class BullishRestClientExchangeApiTrading : IBullishRestClientExchangeApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BullishRestClientExchangeApi _baseClient;
        private readonly ILogger _logger;

        internal BullishRestClientExchangeApiTrading(ILogger logger, BullishRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
            _logger = logger;
        }


    }
}
