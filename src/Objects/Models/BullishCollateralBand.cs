using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish asset collateral band
    /// </summary>
    public class BullishCollateralBand
    {
        /// <summary>
        /// ["<c>collateralPercentage</c>"] Collateral percentage
        /// </summary>
        [JsonPropertyName("collateralPercentage")]
        public decimal CollateralPercentage { get; set; }

        /// <summary>
        /// ["<c>bandLimitUSD</c>"] Band limit in USD
        /// </summary>
        [JsonPropertyName("bandLimitUSD")]
        public decimal BandLimitUSD { get; set; }
    }
}