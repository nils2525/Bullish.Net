using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish market maker protection configuration
    /// </summary>
    public class BullishMmpConfiguration
    {
        /// <summary>
        /// ["<c>underlyingAssetSymbol</c>"] Underlying asset symbol
        /// </summary>
        [JsonPropertyName("underlyingAssetSymbol")]
        public string UnderlyingAsset { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>windowTimeInSeconds</c>"] MMP window time in seconds
        /// </summary>
        [JsonPropertyName("windowTimeInSeconds")]
        public decimal? WindowTimeInSeconds { get; set; }

        /// <summary>
        /// ["<c>frozenTimeInSeconds</c>"] MMP frozen time in seconds
        /// </summary>
        [JsonPropertyName("frozenTimeInSeconds")]
        public decimal? FrozenTimeInSeconds { get; set; }

        /// <summary>
        /// ["<c>quantityLimit</c>"] Quantity limit
        /// </summary>
        [JsonPropertyName("quantityLimit")]
        public decimal? QuantityLimit { get; set; }

        /// <summary>
        /// ["<c>deltaLimit</c>"] Delta limit
        /// </summary>
        [JsonPropertyName("deltaLimit")]
        public decimal? DeltaLimit { get; set; }

        /// <summary>
        /// ["<c>isActive</c>"] Whether the configuration is active
        /// </summary>
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}