using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish fiat deposit instruction
    /// </summary>
    public class BullishFiatDepositInstruction
    {
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
        /// ["<c>accountNumber</c>"] Account number
        /// </summary>
        [JsonPropertyName("accountNumber")]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// ["<c>name</c>"] Account holder name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// ["<c>physicalAddress</c>"] Physical address
        /// </summary>
        [JsonPropertyName("physicalAddress")]
        public string? PhysicalAddress { get; set; }

        /// <summary>
        /// ["<c>memo</c>"] Deposit memo
        /// </summary>
        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// ["<c>bank</c>"] Bank information
        /// </summary>
        [JsonPropertyName("bank")]
        public BullishBank? Bank { get; set; }
    }
}