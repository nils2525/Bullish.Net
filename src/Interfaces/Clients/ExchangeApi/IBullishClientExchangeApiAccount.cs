using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// Bullish Exchange account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBullishClientExchangeApiAccount
    {
        /// <summary>
        /// Login with HMAC
        /// <para><a href="https://api.exchange.bullish.com/docs/api/rest/trading-api/v2/#get-/v1/users/hmac/login" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishAuthResponse>> LoginHmac(CancellationToken ct = default);

        /// <summary>
        /// Get current nonce range
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishNonce>> GetNonceAsync(CancellationToken ct = default);

        /// <summary>
        /// Get all asset accounts
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishAssetAccount[]>> GetAssetAccountsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get asset account by symbol
        /// </summary>
        /// <param name="symbol">The asset symbol</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishAssetAccount>> GetAssetAccountAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get all trading accounts
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishTradingAccount[]>> GetTradingAccountsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get a specific trading account
        /// </summary>
        /// <param name="tradingAccountId">The trading account id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishTradingAccount>> GetTradingAccountAsync(string tradingAccountId, CancellationToken ct = default);

        /// <summary>
        /// Get user trades
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishUserTrade[]>> GetUserTradesAsync(string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get trade by id
        /// </summary>
        /// <param name="tradeId">The trade id</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishUserTrade>> GetUserTradeAsync(string tradeId, CancellationToken ct = default);

        /// <summary>
        /// Get trade history
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BullishUserTrade[]>> GetUserTradeHistoryAsync(string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<object>> LogoutAsync(CancellationToken ct = default);
    }
}
