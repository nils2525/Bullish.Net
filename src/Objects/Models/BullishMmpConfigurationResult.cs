using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish market maker protection configuration result
    /// </summary>
    public class BullishMmpConfigurationResult
    {
        /// <summary>
        /// ["<c>tradingAccountId</c>"] Trading account id
        /// </summary>
        [JsonPropertyName("tradingAccountId")]
        public string TradingAccountId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>message</c>"] Result message
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// ["<c>mmpConfigurations</c>"] Market maker protection configurations
        /// </summary>
        [JsonPropertyName("mmpConfigurations")]
        public BullishMmpConfiguration[] MmpConfigurations { get; set; } = Array.Empty<BullishMmpConfiguration>();
    }
}