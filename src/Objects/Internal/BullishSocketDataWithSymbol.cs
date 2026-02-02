using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Internal
{
    public class BullishSocketDataWithSymbolPublishCreateTimestamp : BullishSocketDataWithSymbolPublishTimestamp
    {
        /// <summary>
        /// Denotes the time the update was broadcasted to connected websockets
        /// </summary>
        [JsonPropertyName("publishedAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime PublishedAtTimestamp { get; set; }
    }

    public class BullishSocketDataWithSymbolPublishTimestamp
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Denotes the time the order was ACK'd by the exchange
        /// </summary>
        [JsonPropertyName("createdAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAtTimestamp { get; set; }
    }
}
