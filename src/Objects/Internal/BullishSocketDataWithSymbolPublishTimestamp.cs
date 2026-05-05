using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Internal
{
    /// <summary>
    /// Bullish socket data with symbol and created timestamp
    /// </summary>
    public class BullishSocketDataWithSymbolPublishTimestamp
    {
        /// <summary>
        /// ["<c>symbol</c>"] Market symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>createdAtTimestamp</c>"] Time the data was created by the exchange
        /// </summary>
        [JsonPropertyName("createdAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAtTimestamp { get; set; }
    }
}