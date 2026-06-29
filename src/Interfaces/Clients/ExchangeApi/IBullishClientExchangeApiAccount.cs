using Bullish.Net.Objects.Models;
using Bullish.Net.Enums;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// Bullish account endpoints. Account endpoints include session management, trading account info, balances, history and wallet info.
    /// </summary>
    public interface IBullishClientExchangeApiAccount
    {
        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/login-user-hmac" />
        /// </summary>
        Task<HttpResult<BullishAuthResponse>> LoginHmac(CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/logout-user" />
        /// </summary>
        Task<HttpResult> LogoutAsync(CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-nonce" />
        /// </summary>
        Task<HttpResult<BullishNonceRange>> GetNonceAsync(CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-trading-accounts" />
        /// </summary>
        Task<HttpResult<BullishTradingAccount[]>> GetTradingAccountsAsync(CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-trading-account-by-id" />
        /// </summary>
        Task<HttpResult<BullishTradingAccount>> GetTradingAccountAsync(string tradingAccountId, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-asset-accounts" />
        /// </summary>
        Task<HttpResult<BullishAccountAsset[]>> GetAssetAccountsAsync(string tradingAccountId, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-asset-account-by-symbol" />
        /// </summary>
        Task<HttpResult<BullishAccountAsset>> GetAssetAccountAsync(string tradingAccountId, string asset, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-derivatives-positions" />
        /// </summary>
        Task<HttpResult<BullishDerivativePosition[]>> GetDerivativePositionsAsync(string? tradingAccountId = null, string? symbol = null, BullishSymbolType? marketType = null, BullishOptionType? optionType = null, string? sort = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-mmp-configuration" />
        /// </summary>
        Task<HttpResult<BullishMmpConfigurationResult>> GetMmpConfigurationAsync(string tradingAccountId, string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-borrow-interest-history" />
        /// </summary>
        Task<HttpResult<BullishPagedResult<BullishBorrowInterest>>> GetBorrowInterestHistoryAsync(string asset, DateTime startTime, DateTime endTime, string? tradingAccountId = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-derivatives-settlement-history" />
        /// </summary>
        Task<HttpResult<BullishPagedResult<BullishDerivativeSettlement>>> GetDerivativeSettlementHistoryAsync(DateTime startTime, DateTime endTime, string? tradingAccountId = null, string? symbol = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-transfer-history" />
        /// </summary>
        Task<HttpResult<BullishPagedResult<BullishTransfer>>> GetTransferHistoryAsync(DateTime startTime, DateTime endTime, string? tradingAccountId = null, string? status = null, string? requestId = null, string? asset = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-custody-transaction-history" />
        /// </summary>
        Task<HttpResult<BullishPagedResult<BullishCustodyTransaction>>> GetCustodyTransactionHistoryAsync(DateTime? startTime = null, DateTime? endTime = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-custody-withdrawal-limits" />
        /// </summary>
        Task<HttpResult<BullishWithdrawalLimit>> GetWithdrawalLimitsAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-crypto-deposit-instructions" />
        /// </summary>
        Task<HttpResult<BullishCryptoDepositInstruction[]>> GetCryptoDepositInstructionsAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-fiat-deposit-instructions" />
        /// </summary>
        Task<HttpResult<BullishFiatDepositInstruction[]>> GetFiatDepositInstructionsAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-crypto-withdrawal-instructions" />
        /// </summary>
        Task<HttpResult<BullishCryptoWithdrawalInstruction[]>> GetCryptoWithdrawalInstructionsAsync(string asset, bool? signed = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/get-fiat-withdrawal-instructions" />
        /// </summary>
        Task<HttpResult<BullishFiatWithdrawalInstruction[]>> GetFiatWithdrawalInstructionsAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/custody-get-self-hosted-verifications" />
        /// </summary>
        Task<HttpResult<BullishSelfHostedWalletVerification[]>> GetSelfHostedWalletVerificationsAsync(string? address = null, string? destinationId = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/custody-initiate-self-hosted-verification" />
        /// </summary>
        Task<HttpResult<BullishSelfHostedWalletVerificationInstruction>> InitiateSelfHostedWalletVerificationAsync(string network, string asset, string address, string label, string requestedDepositAmount, string? memo = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://docs.exchange.bullish.com/rest/api/custody-delete-withdrawal-instructions" />
        /// </summary>
        Task<HttpResult> DeleteWithdrawalInstructionAsync(string destinationId, CancellationToken ct = default);
    }
}
