using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish cancel order command result
    /// </summary>
    public class BullishCancelOrderResult
    {
        /// <summary>
        /// ["<c>commandType</c>"] Command type
        /// </summary>
        [JsonPropertyName("commandType")]
        public string CommandType { get; set; } = string.Empty;

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
        public string? OrderId { get; set; }

        /// <summary>
        /// ["<c>clientOrderId</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOrderId")]
        public string? ClientOrderId { get; set; }
    }
}