using Bullish.Net.Enums;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBullishRestClientExchangeApiExchangeData
    {
        /// <summary>
        /// Gets the server time
        /// <para><a href="https://api-docs.Bullish.com/spot/api/public/reference-data#system-timestamp" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get symbols/instruments
        /// <para><a href="https://api-docs.Bullish.com/spot/api/public/reference-data#symbol-information" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishSymbol[]>> GetSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://api-docs.Bullish.com/spot/api/public/reference-data#currencyv2-information" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishAsset[]>> GetAssetsAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://api-docs.Bullish.com/spot/api/public/market-data#ticker" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishTicker[]>> GetTickersAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://api-docs.Bullish.com/spot/api/public/market-data#ticker" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get a specific market by symbol
        /// </summary>
        /// <param name="symbol">The symbol to get</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishSymbol>> GetSymbolAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get a specific asset by symbol
        /// </summary>
        /// <param name="symbol">The asset symbol to get</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishAsset>> GetAssetAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get the hybrid order book for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get the order book for</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishOrderBook>> GetOrderBookAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get recent trades for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get trades for</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishTrade[]>> GetTradesAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get candlestick/kline data for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get candles for</param>
        /// <param name="timeBucket">The candle interval</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishCandle[]>> GetCandlesAsync(string symbol, BullishCandleInterval timeBucket, CancellationToken ct = default);
    }
}
