using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish create order command result
    /// </summary>
    public class BullishCreateOrderResult
    {
        /// <summary>
        /// ["<c>message</c>"] Result message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>requestId</c>"] Request id
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>clientOrderId</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOrderId")]
        public string? ClientOrderId { get; set; }
    }
}