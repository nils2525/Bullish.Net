using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish nonce range
    /// </summary>
    public class BullishNonceRange
    {
        /// <summary>
        /// ["<c>lowerBound</c>"] Lower bound of the nonce range
        /// </summary>
        [JsonPropertyName("lowerBound")]
        public long LowerBound { get; set; }

        /// <summary>
        /// ["<c>upperBound</c>"] Upper bound of the nonce range
        /// </summary>
        [JsonPropertyName("upperBound")]
        public long UpperBound { get; set; }
    }
}