using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish crypto deposit instruction
    /// </summary>
    public class BullishCryptoDepositInstruction
    {
        /// <summary>
        /// ["<c>network</c>"] Network
        /// </summary>
        [JsonPropertyName("network")]
        public string Network { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>symbol</c>"] Asset symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>memo</c>"] Deposit memo
        /// </summary>
        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// ["<c>address</c>"] Deposit address
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>minimumDepositAmount</c>"] Minimum deposit amount
        /// </summary>
        [JsonPropertyName("minimumDepositAmount")]
        public decimal? MinimumDepositAmount { get; set; }
    }
}