using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish trading account
    /// </summary>
    public class BullishTradingAccount
    {
        /// <summary>
        /// Trading account id
        /// </summary>
        [JsonPropertyName("tradingAccountId")]
        public string TradingAccountId { get; set; } = string.Empty;

        /// <summary>
        /// Trading account name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Account type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Whether the account is the default
        /// </summary>
        [JsonPropertyName("isDefault")]
        public bool IsDefault { get; set; }
    }
}
