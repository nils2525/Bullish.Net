using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    public class BullishTimestamp
    {
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
