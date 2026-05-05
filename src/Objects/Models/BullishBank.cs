using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish bank information
    /// </summary>
    public class BullishBank
    {
        /// <summary>
        /// ["<c>name</c>"] Bank name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// ["<c>accountNumber</c>"] Account number
        /// </summary>
        [JsonPropertyName("accountNumber")]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// ["<c>routingNumber</c>"] Routing number
        /// </summary>
        [JsonPropertyName("routingNumber")]
        public string? RoutingNumber { get; set; }

        /// <summary>
        /// ["<c>routingCode</c>"] Routing code
        /// </summary>
        [JsonPropertyName("routingCode")]
        public string? RoutingCode { get; set; }

        /// <summary>
        /// ["<c>swiftCode</c>"] SWIFT code
        /// </summary>
        [JsonPropertyName("swiftCode")]
        public string? SwiftCode { get; set; }

        /// <summary>
        /// ["<c>iban</c>"] IBAN
        /// </summary>
        [JsonPropertyName("iban")]
        public string? Iban { get; set; }

        /// <summary>
        /// ["<c>physicalAddress</c>"] Physical address
        /// </summary>
        [JsonPropertyName("physicalAddress")]
        public string? PhysicalAddress { get; set; }
    }
}