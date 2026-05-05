using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish order book sequence range
    /// </summary>
    [JsonConverter(typeof(ArrayConverter<BullishOrderBookSequences>))]
    public class BullishOrderBookSequences
    {
        /// <summary>
        /// First sequence number
        /// </summary>
        [ArrayProperty(0)]
        public long FirstSequence { get; set; }

        /// <summary>
        /// Last sequence number
        /// </summary>
        [ArrayProperty(1)]
        public long LastSequence { get; set; }
    }
}