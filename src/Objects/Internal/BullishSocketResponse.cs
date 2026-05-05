using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Internal
{
    /// <summary>
    /// Bullish socket response
    /// </summary>
    internal class BullishSocketResponse : BullishSocketResponseBase
    {
        /// <summary>
        /// ["<c>result</c>"] Subscription result
        /// </summary>
        [JsonPropertyName("result")]
        public BullishSubscriptionResult? Result { get; set; }

        /// <summary>
        /// ["<c>error</c>"] Error response
        /// </summary>
        [JsonPropertyName("error")]
        public BullishError? Error { get; set; }
    }
}