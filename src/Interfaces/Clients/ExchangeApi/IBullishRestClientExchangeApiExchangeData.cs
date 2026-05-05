using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// Bullish Exchange data endpoints. Exchange data includes market data and system status.
    /// </summary>
    public interface IBullishRestClientExchangeApiExchangeData
    {
        /// <summary>
        /// Gets the server time
        /// <para><a href="https://docs.exchange.bullish.com/rest/api/get-exchange-time" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get markets
        /// <para><a href="https://docs.exchange.bullish.com/rest/api/get-markets" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishSymbol[]>> GetSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get assets
        /// <para><a href="https://docs.exchange.bullish.com/rest/api/get-assets" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishAsset[]>> GetAssetsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get tickers
        /// <para><a href="https://docs.exchange.bullish.com/rest/api/get-market-tick" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishTicker[]>> GetTickersAsync(CancellationToken ct = default);

        /// <summary>
        /// Get ticker
        /// <para><a href="https://docs.exchange.bullish.com/rest/api/get-market-tick" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);
    }
}
