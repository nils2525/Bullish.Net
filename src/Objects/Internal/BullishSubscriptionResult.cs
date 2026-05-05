using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Internal
{
    /// <summary>
    /// Bullish subscription result
    /// </summary>
    internal class BullishSubscriptionResult
    {
        /// <summary>
        /// ["<c>responseCode</c>"] Response code
        /// </summary>
        [JsonPropertyName("responseCode")]
        public int ResponseCode { get; set; }

        /// <summary>
        /// ["<c>responseCodeName</c>"] Response code name
        /// </summary>
        [JsonPropertyName("responseCodeName")]
        public string ResponseCodeName { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>message</c>"] Response message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}