using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish borrow interest history entry
    /// </summary>
    public class BullishBorrowInterest
    {
        /// <summary>
        /// ["<c>assetId</c>"] Asset id
        /// </summary>
        [JsonPropertyName("assetId")]
        public string AssetId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>assetSymbol</c>"] Asset symbol
        /// </summary>
        [JsonPropertyName("assetSymbol")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>borrowedQuantity</c>"] Principal borrowed quantity
        /// </summary>
        [JsonPropertyName("borrowedQuantity")]
        public decimal BorrowedQuantity { get; set; }

        /// <summary>
        /// ["<c>totalBorrowedQuantity</c>"] Principal plus interest quantity
        /// </summary>
        [JsonPropertyName("totalBorrowedQuantity")]
        public decimal TotalBorrowedQuantity { get; set; }

        /// <summary>
        /// ["<c>createdAtDatetime</c>"] Borrow interest hour
        /// </summary>
        [JsonPropertyName("createdAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ["<c>createdAtTimestamp</c>"] Borrow interest timestamp
        /// </summary>
        [JsonPropertyName("createdAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAtTimestamp { get; set; }
    }
}