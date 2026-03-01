using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish nonce range
    /// </summary>
    public class BullishNonce
    {
        /// <summary>
        /// Lower bound nonce
        /// </summary>
        [JsonPropertyName("lowerBound")]
        public long LowerBound { get; set; }

        /// <summary>
        /// Upper bound nonce
        /// </summary>
        [JsonPropertyName("upperBound")]
        public long UpperBound { get; set; }
    }
}
