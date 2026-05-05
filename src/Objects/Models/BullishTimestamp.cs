using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish exchange time
    /// </summary>
    public class BullishTimestamp
    {
        /// <summary>
        /// ["<c>timestamp</c>"] Current exchange timestamp
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// ["<c>datetime</c>"] Current exchange time
        /// </summary>
        [JsonPropertyName("datetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Datetime { get; set; }
    }
}
