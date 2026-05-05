using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish custody transaction
    /// </summary>
    public class BullishCustodyTransaction
    {
        /// <summary>
        /// ["<c>custodyTransactionId</c>"] Custody transaction id
        /// </summary>
        [JsonPropertyName("custodyTransactionId")]
        public string CustodyTransactionId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>direction</c>"] Transaction direction
        /// </summary>
        [JsonPropertyName("direction")]
        public string Direction { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>quantity</c>"] Transaction quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// ["<c>symbol</c>"] Asset symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>network</c>"] Network
        /// </summary>
        [JsonPropertyName("network")]
        public string? Network { get; set; }

        /// <summary>
        /// ["<c>fee</c>"] Withdrawal fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal? Fee { get; set; }

        /// <summary>
        /// ["<c>memo</c>"] Transaction memo
        /// </summary>
        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// ["<c>createdAtDateTime</c>"] Transaction creation time
        /// </summary>
        [JsonPropertyName("createdAtDateTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// ["<c>createdAtDatetime</c>"] Transaction creation time
        /// </summary>
        [JsonPropertyName("createdAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAtDatetime
        {
            get => CreatedAt;
            set => CreatedAt = value;
        }

        /// <summary>
        /// ["<c>status</c>"] Transaction status
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>transactionDetails</c>"] Transaction details
        /// </summary>
        [JsonPropertyName("transactionDetails")]
        public BullishCustodyTransactionDetails? TransactionDetails { get; set; }
    }
}