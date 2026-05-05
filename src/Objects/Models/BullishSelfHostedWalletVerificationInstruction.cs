using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish self-hosted wallet verification instruction
    /// </summary>
    public class BullishSelfHostedWalletVerificationInstruction
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
        /// ["<c>depositAddress</c>"] Verification deposit address
        /// </summary>
        [JsonPropertyName("depositAddress")]
        public string DepositAddress { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>depositMemo</c>"] Verification deposit memo
        /// </summary>
        [JsonPropertyName("depositMemo")]
        public string? DepositMemo { get; set; }

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