using System.Text.Json.Serialization;
using Bullish.Net.Converters;
using Bullish.Net.Objects.Internal;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish order book snapshot or update
    /// </summary>
    public class BullishOrderBook : BullishSocketDataWithSymbolPublishTimestamp
    {
        /// <summary>
        /// ["<c>timestamp</c>"] Order book snapshot timestamp
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// ["<c>sequenceNumberRange</c>"] Lower and upper bound of sequence numbers
        /// </summary>
        [JsonPropertyName("sequenceNumberRange")]
        public BullishOrderBookSequences Sequences { get; set; } = new();

        /// <summary>
        /// ["<c>bids</c>"] Bid entries
        /// </summary>
        [JsonPropertyName("bids")]
        [JsonConverter(typeof(BullishOrderBookEntryArrayConverter))]
        public IEnumerable<BullishOrderBookEntry> Bids { get; set; } = Array.Empty<BullishOrderBookEntry>();

        /// <summary>
        /// ["<c>asks</c>"] Ask entries
        /// </summary>
        [JsonPropertyName("asks")]
        [JsonConverter(typeof(BullishOrderBookEntryArrayConverter))]
        public IEnumerable<BullishOrderBookEntry> Asks { get; set; } = Array.Empty<BullishOrderBookEntry>();
    }
}
