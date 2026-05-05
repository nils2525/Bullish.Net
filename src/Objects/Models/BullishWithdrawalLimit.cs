using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish withdrawal limit
    /// </summary>
    public class BullishWithdrawalLimit
    {
        /// <summary>
        /// ["<c>symbol</c>"] Asset symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>available</c>"] Available withdrawal limit
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }

        /// <summary>
        /// ["<c>twentyFourHour</c>"] 24 hour withdrawal limit
        /// </summary>
        [JsonPropertyName("twentyFourHour")]
        public decimal TwentyFourHour { get; set; }
    }
}