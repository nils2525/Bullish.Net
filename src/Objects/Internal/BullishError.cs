using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Internal
{
    /// <summary>
    /// Bullish socket error
    /// </summary>
    internal class BullishError
    {
        /// <summary>
        /// ["<c>code</c>"] Error code
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// ["<c>errorCode</c>"] Bullish error code
        /// </summary>
        [JsonPropertyName("errorCode")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// ["<c>errorCodeName</c>"] Bullish error code name
        /// </summary>
        [JsonPropertyName("errorCodeName")]
        public string ErrorCodeName { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>message</c>"] Error message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}