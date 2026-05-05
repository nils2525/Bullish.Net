using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish margin profile
    /// </summary>
    public class BullishMarginProfile
    {
        /// <summary>
        /// ["<c>initialMarketRiskMultiplierPct</c>"] Initial market risk multiplier percentage
        /// </summary>
        [JsonPropertyName("initialMarketRiskMultiplierPct")]
        public decimal? InitialMarketRiskMultiplierPct { get; set; }

        /// <summary>
        /// ["<c>warningMarketRiskMultiplierPct</c>"] Warning market risk multiplier percentage
        /// </summary>
        [JsonPropertyName("warningMarketRiskMultiplierPct")]
        public decimal? WarningMarketRiskMultiplierPct { get; set; }

        /// <summary>
        /// ["<c>liquidationMarketRiskMultiplierPct</c>"] Liquidation market risk multiplier percentage
        /// </summary>
        [JsonPropertyName("liquidationMarketRiskMultiplierPct")]
        public decimal? LiquidationMarketRiskMultiplierPct { get; set; }

        /// <summary>
        /// ["<c>fullLiquidationMarketRiskMultiplierPct</c>"] Full liquidation market risk multiplier percentage
        /// </summary>
        [JsonPropertyName("fullLiquidationMarketRiskMultiplierPct")]
        public decimal? FullLiquidationMarketRiskMultiplierPct { get; set; }

        /// <summary>
        /// ["<c>defaultedMarketRiskMultiplierPct</c>"] Defaulted market risk multiplier percentage
        /// </summary>
        [JsonPropertyName("defaultedMarketRiskMultiplierPct")]
        public decimal? DefaultedMarketRiskMultiplierPct { get; set; }
    }
}