using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Internal
{
    /// <summary>
    /// Bullish socket data with symbol, published timestamp and created timestamp
    /// </summary>
    public class BullishSocketDataWithSymbolPublishCreateTimestamp : BullishSocketDataWithSymbolPublishTimestamp
    {
        /// <summary>
        /// ["<c>publishedAtTimestamp</c>"] Time the update was broadcast to connected websockets
        /// </summary>
        [JsonPropertyName("publishedAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime PublishedAtTimestamp { get; set; }
    }
}