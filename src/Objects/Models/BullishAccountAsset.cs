using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish trading account asset balance
    /// </summary>
    public class BullishAccountAsset
    {
        /// <summary>
        /// ["<c>tradingAccountId</c>"] Trading account id
        /// </summary>
        [JsonPropertyName("tradingAccountId")]
        public string TradingAccountId { get; set; } = string.Empty;

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
        /// ["<c>availableQuantity</c>"] Available quantity
        /// </summary>
        [JsonPropertyName("availableQuantity")]
        public decimal AvailableQuantity { get; set; }

        /// <summary>
        /// ["<c>borrowedQuantity</c>"] Borrowed quantity
        /// </summary>
        [JsonPropertyName("borrowedQuantity")]
        public decimal BorrowedQuantity { get; set; }

        /// <summary>
        /// ["<c>lockedQuantity</c>"] Locked quantity
        /// </summary>
        [JsonPropertyName("lockedQuantity")]
        public decimal LockedQuantity { get; set; }

        /// <summary>
        /// ["<c>loanedQuantity</c>"] Loaned quantity
        /// </summary>
        [JsonPropertyName("loanedQuantity")]
        public decimal LoanedQuantity { get; set; }

        /// <summary>
        /// ["<c>updatedAtDatetime</c>"] Last update time
        /// </summary>
        [JsonPropertyName("updatedAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// ["<c>updatedAtTimestamp</c>"] Last update timestamp
        /// </summary>
        [JsonPropertyName("updatedAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdatedAtTimestamp { get; set; }

        /// <summary>
        /// ["<c>publishedAtTimestamp</c>"] Socket publish timestamp
        /// </summary>
        [JsonPropertyName("publishedAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? PublishedAtTimestamp { get; set; }
    }
}