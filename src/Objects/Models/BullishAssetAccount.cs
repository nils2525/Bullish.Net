using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish asset account
    /// </summary>
    public class BullishAssetAccount
    {
        /// <summary>
        /// Asset account id
        /// </summary>
        [JsonPropertyName("assetAccountId")]
        public string AssetAccountId { get; set; } = string.Empty;

        /// <summary>
        /// Asset symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Available balance
        /// </summary>
        [JsonPropertyName("availableBalance")]
        public decimal AvailableBalance { get; set; }

        /// <summary>
        /// Total balance
        /// </summary>
        [JsonPropertyName("totalBalance")]
        public decimal TotalBalance { get; set; }

        /// <summary>
        /// Reserved balance (in open orders)
        /// </summary>
        [JsonPropertyName("reservedBalance")]
        public decimal ReservedBalance { get; set; }
    }
}
