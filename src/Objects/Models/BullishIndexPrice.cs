using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish asset index price.
    /// </summary>
    public class BullishIndexPrice
    {
        /// <summary>
        /// ["<c>price</c>"] Index price.
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// ["<c>assetSymbol</c>"] Asset symbol.
        /// </summary>
        [JsonPropertyName("assetSymbol")]
        public string AssetSymbol { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>updatedAtDatetime</c>"] Last update time.
        /// </summary>
        [JsonPropertyName("updatedAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// ["<c>updatedAtTimestamp</c>"] Last update timestamp.
        /// </summary>
        [JsonPropertyName("updatedAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdatedAtTimestamp { get; set; }
    }
}
