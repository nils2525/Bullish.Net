using Bullish.Net.Interfaces.Clients.ExchangeApi;
using Bullish.Net.Enums;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class BullishRestClientExchangeApiAccount : IBullishClientExchangeApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BullishRestClientExchangeApi _baseClient;

        internal BullishRestClientExchangeApiAccount(BullishRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
        }

        public Task<WebCallResult<BullishAuthResponse>> LoginHmac(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/users/hmac/login", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishAuthResponse>(request, null, ct);
        }

        public async Task<WebCallResult> LogoutAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/users/logout", BullishExchange.RateLimiter.Generic, 1, true);
            var result = await _baseClient.SendAsync(request, null, ct).ConfigureAwait(false);
            if (result.Success)
                _baseClient.AuthenticationProvider?.ClearAuthorization();

            return result;
        }

        public Task<WebCallResult<BullishNonceRange>> GetNonceAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/nonce", BullishExchange.RateLimiter.Generic, 1, false);
            return _baseClient.SendAsync<BullishNonceRange>(request, null, ct);
        }

        public Task<WebCallResult<BullishTradingAccount[]>> GetTradingAccountsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/accounts/trading-accounts", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishTradingAccount[]>(request, null, ct);
        }

        public Task<WebCallResult<BullishTradingAccount>> GetTradingAccountAsync(string tradingAccountId, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/accounts/trading-accounts/{tradingAccountId}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishTradingAccount>(request, null, ct);
        }

        public Task<WebCallResult<BullishAccountAsset[]>> GetAssetAccountsAsync(string tradingAccountId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "tradingAccountId", tradingAccountId }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/accounts/asset", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishAccountAsset[]>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishAccountAsset>> GetAssetAccountAsync(string tradingAccountId, string asset, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "tradingAccountId", tradingAccountId }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/accounts/asset/{asset}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishAccountAsset>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishDerivativePosition[]>> GetDerivativePositionsAsync(string? tradingAccountId = null, string? symbol = null, BullishSymbolType? marketType = null, BullishOptionType? optionType = null, string? sort = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("tradingAccountId", tradingAccountId);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalEnum("marketType", marketType);
            parameters.AddOptionalEnum("optionType", optionType);
            parameters.AddOptional("sort", sort);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/derivatives-positions", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishDerivativePosition[]>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishMmpConfigurationResult>> GetMmpConfigurationAsync(string tradingAccountId, string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "tradingAccountId", tradingAccountId }
            };
            parameters.AddOptional("symbol", symbol);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v2/mmp-configuration", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishMmpConfigurationResult>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishBorrowInterest[]>> GetBorrowInterestHistoryAsync(string asset, DateTime startTime, DateTime endTime, string? tradingAccountId = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "assetSymbol", asset },
                { "createdAtDatetime[gte]", BullishParameterFormats.FormatDateTime(startTime) },
                { "createdAtDatetime[lte]", BullishParameterFormats.FormatDateTime(endTime) }
            };
            AddOptionalHistoryParameters(parameters, tradingAccountId, pageSize, nextPage, previousPage);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/history/borrow-interest", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishBorrowInterest[]>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishDerivativeSettlement[]>> GetDerivativeSettlementHistoryAsync(DateTime startTime, DateTime endTime, string? tradingAccountId = null, string? symbol = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "settlementDatetime[gte]", BullishParameterFormats.FormatDateTime(startTime) },
                { "settlementDatetime[lte]", BullishParameterFormats.FormatDateTime(endTime) }
            };
            parameters.AddOptional("symbol", symbol);
            AddOptionalHistoryParameters(parameters, tradingAccountId, pageSize, nextPage, previousPage);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/history/derivatives-settlement", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishDerivativeSettlement[]>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishTransfer[]>> GetTransferHistoryAsync(DateTime startTime, DateTime endTime, string? tradingAccountId = null, string? status = null, string? requestId = null, string? asset = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "createdAtDatetime[gte]", BullishParameterFormats.FormatDateTime(startTime) },
                { "createdAtDatetime[lte]", BullishParameterFormats.FormatDateTime(endTime) }
            };
            parameters.AddOptional("status", status);
            parameters.AddOptional("requestId", requestId);
            parameters.AddOptional("assetSymbol", asset);
            AddOptionalHistoryParameters(parameters, tradingAccountId, pageSize, nextPage, previousPage);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/history/transfer", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishTransfer[]>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishPagedResult<BullishCustodyTransaction>>> GetCustodyTransactionHistoryAsync(DateTime? startTime = null, DateTime? endTime = null, int? pageSize = null, string? nextPage = null, string? previousPage = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("createdAtDatetime[gte]", startTime == null ? null : BullishParameterFormats.FormatDateTime(startTime.Value));
            parameters.AddOptional("createdAtDatetime[lte]", endTime == null ? null : BullishParameterFormats.FormatDateTime(endTime.Value));
            AddOptionalPaginationParameters(parameters, pageSize, nextPage, previousPage);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/wallets/transactions", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishPagedResult<BullishCustodyTransaction>>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishWithdrawalLimit>> GetWithdrawalLimitsAsync(string asset, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/wallets/limits/{asset}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishWithdrawalLimit>(request, null, ct);
        }

        public Task<WebCallResult<BullishCryptoDepositInstruction[]>> GetCryptoDepositInstructionsAsync(string asset, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/wallets/deposit-instructions/crypto/{asset}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishCryptoDepositInstruction[]>(request, null, ct);
        }

        public Task<WebCallResult<BullishFiatDepositInstruction[]>> GetFiatDepositInstructionsAsync(string asset, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/wallets/deposit-instructions/fiat/{asset}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishFiatDepositInstruction[]>(request, null, ct);
        }

        public Task<WebCallResult<BullishCryptoWithdrawalInstruction[]>> GetCryptoWithdrawalInstructionsAsync(string asset, bool? signed = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("signed", signed?.ToString().ToLowerInvariant());

            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/wallets/withdrawal-instructions/crypto/{asset}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishCryptoWithdrawalInstruction[]>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishFiatWithdrawalInstruction[]>> GetFiatWithdrawalInstructionsAsync(string asset, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"/v1/wallets/withdrawal-instructions/fiat/{asset}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishFiatWithdrawalInstruction[]>(request, null, ct);
        }

        public Task<WebCallResult<BullishSelfHostedWalletVerification[]>> GetSelfHostedWalletVerificationsAsync(string? address = null, string? destinationId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("address", address);
            parameters.AddOptional("destinationId", destinationId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/v1/wallets/self-hosted/verification-attempts", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishSelfHostedWalletVerification[]>(request, parameters, ct);
        }

        public Task<WebCallResult<BullishSelfHostedWalletVerificationInstruction>> InitiateSelfHostedWalletVerificationAsync(string network, string asset, string address, string label, string requestedDepositAmount, string? memo = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "network", network },
                { "symbol", asset },
                { "address", address },
                { "label", label },
                { "requestedDepositAmount", requestedDepositAmount }
            };
            parameters.AddOptional("memo", memo);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/v1/wallets/self-hosted/initiate", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync<BullishSelfHostedWalletVerificationInstruction>(request, parameters, ct);
        }

        public Task<WebCallResult> DeleteWithdrawalInstructionAsync(string destinationId, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Delete, $"/v1/wallets/withdrawal-instructions/{destinationId}", BullishExchange.RateLimiter.Generic, 1, true);
            return _baseClient.SendAsync(request, null, ct);
        }

        private static void AddOptionalHistoryParameters(ParameterCollection parameters, string? tradingAccountId, int? pageSize, string? nextPage, string? previousPage)
        {
            parameters.AddOptional("tradingAccountId", tradingAccountId);
            AddOptionalPaginationParameters(parameters, pageSize, nextPage, previousPage);
        }

        private static void AddOptionalPaginationParameters(ParameterCollection parameters, int? pageSize, string? nextPage, string? previousPage)
        {
            parameters.AddOptional("_pageSize", pageSize);
            parameters.AddOptional("_nextPage", nextPage);
            parameters.AddOptional("_previousPage", previousPage);
        }
    }
}
