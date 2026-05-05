using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish account transfer history entry
    /// </summary>
    public class BullishTransfer
    {
        /// <summary>
        /// ["<c>requestId</c>"] Transfer request id
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>toTradingAccountId</c>"] Recipient trading account id
        /// </summary>
        [JsonPropertyName("toTradingAccountId")]
        public string ToTradingAccountId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>fromTradingAccountId</c>"] Sender trading account id
        /// </summary>
        [JsonPropertyName("fromTradingAccountId")]
        public string FromTradingAccountId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>assetSymbol</c>"] Asset symbol
        /// </summary>
        [JsonPropertyName("assetSymbol")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>quantity</c>"] Transfer quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// ["<c>status</c>"] Transfer status
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>statusReasonCode</c>"] Transfer status reason code
        /// </summary>
        [JsonPropertyName("statusReasonCode")]
        public string? StatusReasonCode { get; set; }

        /// <summary>
        /// ["<c>statusReason</c>"] Transfer status reason
        /// </summary>
        [JsonPropertyName("statusReason")]
        public string? StatusReason { get; set; }

        /// <summary>
        /// ["<c>createdAtTimestamp</c>"] Transfer creation timestamp
        /// </summary>
        [JsonPropertyName("createdAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAtTimestamp { get; set; }

        /// <summary>
        /// ["<c>createdAtDatetime</c>"] Transfer creation time
        /// </summary>
        [JsonPropertyName("createdAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }
    }
}