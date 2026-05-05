using CryptoExchange.Net.Objects;

namespace Bullish.Net.Clients.ExchangeApi
{
    internal static class BullishPaginationParameters
    {
        #region Methods
        internal static void AddMetaData(ParameterCollection parameters)
            => parameters.Add("_metaData", "true");

        internal static void AddOptionalHistory(ParameterCollection parameters, string? tradingAccountId, int? pageSize, string? nextPage, string? previousPage)
        {
            parameters.AddOptional("tradingAccountId", tradingAccountId);
            AddMetaData(parameters);
            AddOptionalPagination(parameters, pageSize, nextPage, previousPage);
        }

        internal static void AddOptionalPagination(ParameterCollection parameters, int? pageSize, string? nextPage, string? previousPage)
        {
            parameters.AddOptional("_pageSize", pageSize);
            parameters.AddOptional("_nextPage", nextPage);
            parameters.AddOptional("_previousPage", previousPage);
        }
        #endregion
    }
}
