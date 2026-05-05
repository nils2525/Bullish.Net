using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish fiat withdrawal instruction
    /// </summary>
    public class BullishFiatWithdrawalInstruction
    {
        /// <summary>
        /// ["<c>destinationId</c>"] Destination id
        /// </summary>
        [JsonPropertyName("destinationId")]
        public string DestinationId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>accountNumber</c>"] Bank account number
        /// </summary>
        [JsonPropertyName("accountNumber")]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// ["<c>network</c>"] Fiat network
        /// </summary>
        [JsonPropertyName("network")]
        public string Network { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>symbol</c>"] Fiat symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>name</c>"] Bank name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// ["<c>physicalAddress</c>"] Bank physical address
        /// </summary>
        [JsonPropertyName("physicalAddress")]
        public string? PhysicalAddress { get; set; }

        /// <summary>
        /// ["<c>fee</c>"] Withdrawal fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal? Fee { get; set; }

        /// <summary>
        /// ["<c>memo</c>"] Withdrawal memo
        /// </summary>
        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// ["<c>bank</c>"] Bank information
        /// </summary>
        [JsonPropertyName("bank")]
        public BullishBank? Bank { get; set; }

        /// <summary>
        /// ["<c>intermediaryBank</c>"] Intermediary bank information
        /// </summary>
        [JsonPropertyName("intermediaryBank")]
        public BullishBank? IntermediaryBank { get; set; }
    }
}