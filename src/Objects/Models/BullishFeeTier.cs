using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish market fee tier
    /// </summary>
    public class BullishFeeTier
    {
        /// <summary>
        /// ["<c>feeTierId</c>"] Fee tier id
        /// </summary>
        [JsonPropertyName("feeTierId")]
        public int FeeTierId { get; set; }

        /// <summary>
        /// ["<c>staticSpreadFee</c>"] Static spread fee
        /// </summary>
        [JsonPropertyName("staticSpreadFee")]
        public decimal StaticSpreadFee { get; set; }

        /// <summary>
        /// ["<c>isDislocationEnabled</c>"] Whether dislocation handling is enabled
        /// </summary>
        [JsonPropertyName("isDislocationEnabled")]
        public bool IsDislocationEnabled { get; set; }
    }
}