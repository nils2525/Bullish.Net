using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish position greeks
    /// </summary>
    public class BullishPositionGreeks
    {
        /// <summary>
        /// ["<c>delta</c>"] Delta
        /// </summary>
        [JsonPropertyName("delta")]
        public decimal? Delta { get; set; }

        /// <summary>
        /// ["<c>gamma</c>"] Gamma
        /// </summary>
        [JsonPropertyName("gamma")]
        public decimal? Gamma { get; set; }

        /// <summary>
        /// ["<c>theta</c>"] Theta
        /// </summary>
        [JsonPropertyName("theta")]
        public decimal? Theta { get; set; }

        /// <summary>
        /// ["<c>vega</c>"] Vega
        /// </summary>
        [JsonPropertyName("vega")]
        public decimal? Vega { get; set; }
    }
}