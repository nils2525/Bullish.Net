using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish self-hosted wallet verification
    /// </summary>
    public class BullishSelfHostedWalletVerification
    {
        /// <summary>
        /// ["<c>destinationId</c>"] Destination id
        /// </summary>
        [JsonPropertyName("destinationId")]
        public string DestinationId { get; set; } = string.Empty;

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
        /// ["<c>address</c>"] Wallet address
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>memo</c>"] Wallet memo
        /// </summary>
        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// ["<c>verificationStatus</c>"] Verification status
        /// </summary>
        [JsonPropertyName("verificationStatus")]
        public string VerificationStatus { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>requestedDepositAmount</c>"] Requested deposit amount
        /// </summary>
        [JsonPropertyName("requestedDepositAmount")]
        public decimal RequestedDepositAmount { get; set; }

        /// <summary>
        /// ["<c>verificationAmount</c>"] Verification amount
        /// </summary>
        [JsonPropertyName("verificationAmount")]
        public decimal VerificationAmount { get; set; }

        /// <summary>
        /// ["<c>totalDepositAmount</c>"] Total deposit amount
        /// </summary>
        [JsonPropertyName("totalDepositAmount")]
        public decimal TotalDepositAmount { get; set; }

        /// <summary>
        /// ["<c>verificationExpiryTime</c>"] Verification expiry time
        /// </summary>
        [JsonPropertyName("verificationExpiryTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime VerificationExpiryTime { get; set; }
    }
}