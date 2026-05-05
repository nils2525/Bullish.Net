using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish crypto withdrawal instruction
    /// </summary>
    public class BullishCryptoWithdrawalInstruction
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
        /// ["<c>address</c>"] Withdrawal address
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>fee</c>"] Withdrawal fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// ["<c>memo</c>"] Withdrawal memo
        /// </summary>
        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// ["<c>label</c>"] Destination label
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>destinationId</c>"] Destination id
        /// </summary>
        [JsonPropertyName("destinationId")]
        public string DestinationId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>vaspName</c>"] Destination VASP name
        /// </summary>
        [JsonPropertyName("vaspName")]
        public string? VaspName { get; set; }

        /// <summary>
        /// ["<c>userWalletType</c>"] User wallet type
        /// </summary>
        [JsonPropertyName("userWalletType")]
        public string UserWalletType { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>signed</c>"] Whether the destination has been signed
        /// </summary>
        [JsonPropertyName("signed")]
        public bool Signed { get; set; }
    }
}