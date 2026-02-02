using System.Text.Json.Serialization;
using Bullish.Net.Converters;
using Bullish.Net.Objects.Internal;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;

namespace Bullish.Net.Objects.Models
{
    public class BullishOrderBook : BullishSocketDataWithSymbolPublishTimestamp
    {
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// array of size 2 where first element denotes lower bound, second element denotes upper bound of sequence numbers 
        /// lower and upper bound are equal for initial snapshot; this may differ for subsequent snapshots
        /// </summary>
        [JsonPropertyName("sequenceNumberRange")]
        public BullishOrderBookSequences Sequences { get; set; } = new();

        [JsonPropertyName("bids")]
        [JsonConverter(typeof(BullishOrderBookEntryArrayConverter))]
        public IEnumerable<BullishOrderBookEntry> Bids { get; set; } = Array.Empty<BullishOrderBookEntry>();

        [JsonPropertyName("asks")]
        [JsonConverter(typeof(BullishOrderBookEntryArrayConverter))]
        public IEnumerable<BullishOrderBookEntry> Asks { get; set; } = Array.Empty<BullishOrderBookEntry>();
    }

    [JsonConverter(typeof(ArrayConverter<BullishOrderBookSequences>))]
    public class BullishOrderBookSequences
    {
        [ArrayProperty(0)]
        public long FirstSequence { get; set; }

        [ArrayProperty(1)]
        public long LastSequence { get; set; }
    }

    public class BullishOrderBookEntry : ISymbolOrderBookEntry
    {
        public decimal Price { get; set; }

        public decimal Quantity { get; set; }
    }
}
