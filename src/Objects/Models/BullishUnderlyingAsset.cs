using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish underlying asset risk information
    /// </summary>
    public class BullishUnderlyingAsset
    {
        /// <summary>
        /// ["<c>symbol</c>"] Asset symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>assetId</c>"] Asset id
        /// </summary>
        [JsonPropertyName("assetId")]
        public string AssetId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>bpmMinReturnStart</c>"] BPM minimum return at transition start
        /// </summary>
        [JsonPropertyName("bpmMinReturnStart")]
        public decimal? BpmMinReturnStart { get; set; }

        /// <summary>
        /// ["<c>bpmMinReturnEnd</c>"] BPM minimum return at transition end
        /// </summary>
        [JsonPropertyName("bpmMinReturnEnd")]
        public decimal? BpmMinReturnEnd { get; set; }

        /// <summary>
        /// ["<c>bpmMaxReturnStart</c>"] BPM maximum return at transition start
        /// </summary>
        [JsonPropertyName("bpmMaxReturnStart")]
        public decimal? BpmMaxReturnStart { get; set; }

        /// <summary>
        /// ["<c>bpmMaxReturnEnd</c>"] BPM maximum return at transition end
        /// </summary>
        [JsonPropertyName("bpmMaxReturnEnd")]
        public decimal? BpmMaxReturnEnd { get; set; }

        /// <summary>
        /// ["<c>marketRiskFloorPctStart</c>"] Market risk floor percentage at transition start
        /// </summary>
        [JsonPropertyName("marketRiskFloorPctStart")]
        public decimal? MarketRiskFloorPctStart { get; set; }

        /// <summary>
        /// ["<c>marketRiskFloorPctEnd</c>"] Market risk floor percentage at transition end
        /// </summary>
        [JsonPropertyName("marketRiskFloorPctEnd")]
        public decimal? MarketRiskFloorPctEnd { get; set; }

        /// <summary>
        /// ["<c>bpmTransitionDateTimeStart</c>"] BPM transition start time
        /// </summary>
        [JsonPropertyName("bpmTransitionDateTimeStart")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? BpmTransitionStartTime { get; set; }

        /// <summary>
        /// ["<c>bpmTransitionDateTimeEnd</c>"] BPM transition end time
        /// </summary>
        [JsonPropertyName("bpmTransitionDateTimeEnd")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? BpmTransitionEndTime { get; set; }
    }
}