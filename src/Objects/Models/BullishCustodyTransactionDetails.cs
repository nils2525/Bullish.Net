using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish custody transaction details
    /// </summary>
    public class BullishCustodyTransactionDetails
    {
        /// <summary>
        /// ["<c>address</c>"] Network address
        /// </summary>
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        /// <summary>
        /// ["<c>transactionHash</c>"] Transaction hash
        /// </summary>
        [JsonPropertyName("transactionHash")]
        public string? TransactionHash { get; set; }

        /// <summary>
        /// ["<c>blockchainTxId</c>"] Blockchain transaction id
        /// </summary>
        [JsonPropertyName("blockchainTxId")]
        public string? BlockchainTransactionId { get; set; }

        /// <summary>
        /// ["<c>swiftUetr</c>"] SWIFT UETR
        /// </summary>
        [JsonPropertyName("swiftUetr")]
        public string? SwiftUetr { get; set; }

        /// <summary>
        /// ["<c>destinationId</c>"] Destination id
        /// </summary>
        [JsonPropertyName("destinationId")]
        public string? DestinationId { get; set; }
    }
}