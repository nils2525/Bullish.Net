using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish trading account information
    /// </summary>
    public class BullishTradingAccount
    {
        /// <summary>
        /// ["<c>isBorrowing</c>"] Whether the trading account is borrowing
        /// </summary>
        [JsonPropertyName("isBorrowing")]
        public bool? IsBorrowing { get; set; }

        /// <summary>
        /// ["<c>isLending</c>"] Whether the trading account is lending
        /// </summary>
        [JsonPropertyName("isLending")]
        public bool? IsLending { get; set; }

        /// <summary>
        /// ["<c>maxInitialLeverage</c>"] Maximum initial leverage
        /// </summary>
        [JsonPropertyName("maxInitialLeverage")]
        public decimal? MaxInitialLeverage { get; set; }

        /// <summary>
        /// ["<c>tradingAccountId</c>"] Trading account id
        /// </summary>
        [JsonPropertyName("tradingAccountId")]
        public string TradingAccountId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>tradingAccountName</c>"] Trading account name
        /// </summary>
        [JsonPropertyName("tradingAccountName")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>tradingAccountDescription</c>"] Trading account description
        /// </summary>
        [JsonPropertyName("tradingAccountDescription")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>isPrimaryAccount</c>"] Whether this is the primary trading account
        /// </summary>
        [JsonPropertyName("isPrimaryAccount")]
        public bool? IsPrimaryAccount { get; set; }

        /// <summary>
        /// ["<c>rateLimitToken</c>"] Trading account rate limit token
        /// </summary>
        [JsonPropertyName("rateLimitToken")]
        public string? RateLimitToken { get; set; }

        /// <summary>
        /// ["<c>isDefaulted</c>"] Whether the trading account is defaulted
        /// </summary>
        [JsonPropertyName("isDefaulted")]
        public bool? IsDefaulted { get; set; }

        /// <summary>
        /// ["<c>tradeFeeRate</c>"] Trade fee rates assigned to the account
        /// </summary>
        [JsonPropertyName("tradeFeeRate")]
        public BullishTradeFeeRate[] TradeFeeRate { get; set; } = Array.Empty<BullishTradeFeeRate>();

        /// <summary>
        /// ["<c>riskLimitUSD</c>"] Maximum allowed borrowing in USD
        /// </summary>
        [JsonPropertyName("riskLimitUSD")]
        public decimal? RiskLimitUSD { get; set; }

        /// <summary>
        /// ["<c>totalLiabilitiesUSD</c>"] Total liabilities in USD
        /// </summary>
        [JsonPropertyName("totalLiabilitiesUSD")]
        public decimal? TotalLiabilitiesUSD { get; set; }

        /// <summary>
        /// ["<c>totalBorrowedUSD</c>"] Total borrowed value in USD
        /// </summary>
        [JsonPropertyName("totalBorrowedUSD")]
        public decimal? TotalBorrowedUSD { get; set; }

        /// <summary>
        /// ["<c>totalCollateralUSD</c>"] Total collateral value in USD
        /// </summary>
        [JsonPropertyName("totalCollateralUSD")]
        public decimal? TotalCollateralUSD { get; set; }

        /// <summary>
        /// ["<c>initialMarginUSD</c>"] Initial margin in USD
        /// </summary>
        [JsonPropertyName("initialMarginUSD")]
        public decimal? InitialMarginUSD { get; set; }

        /// <summary>
        /// ["<c>warningMarginUSD</c>"] Warning margin in USD
        /// </summary>
        [JsonPropertyName("warningMarginUSD")]
        public decimal? WarningMarginUSD { get; set; }

        /// <summary>
        /// ["<c>liquidationMarginUSD</c>"] Liquidation margin in USD
        /// </summary>
        [JsonPropertyName("liquidationMarginUSD")]
        public decimal? LiquidationMarginUSD { get; set; }

        /// <summary>
        /// ["<c>fullLiquidationMarginUSD</c>"] Full liquidation margin in USD
        /// </summary>
        [JsonPropertyName("fullLiquidationMarginUSD")]
        public decimal? FullLiquidationMarginUSD { get; set; }

        /// <summary>
        /// ["<c>defaultedMarginUSD</c>"] Defaulted margin in USD
        /// </summary>
        [JsonPropertyName("defaultedMarginUSD")]
        public decimal? DefaultedMarginUSD { get; set; }

        /// <summary>
        /// ["<c>endCustomerId</c>"] End customer id used for self-trade prevention
        /// </summary>
        [JsonPropertyName("endCustomerId")]
        public string? EndCustomerId { get; set; }

        /// <summary>
        /// ["<c>isConcentrationRiskEnabled</c>"] Whether concentration risk checks are enforced
        /// </summary>
        [JsonPropertyName("isConcentrationRiskEnabled")]
        public bool? IsConcentrationRiskEnabled { get; set; }

        /// <summary>
        /// ["<c>liquidityAddonUSD</c>"] Expected liquidation market impact in USD
        /// </summary>
        [JsonPropertyName("liquidityAddonUSD")]
        public decimal? LiquidityAddonUsd { get; set; }

        /// <summary>
        /// ["<c>marketRiskUSD</c>"] Worst possible portfolio loss in USD
        /// </summary>
        [JsonPropertyName("marketRiskUSD")]
        public decimal? MarketRiskUsd { get; set; }

        /// <summary>
        /// ["<c>marginProfile</c>"] Margin profile
        /// </summary>
        [JsonPropertyName("marginProfile")]
        public BullishMarginProfile? MarginProfile { get; set; }
    }
}