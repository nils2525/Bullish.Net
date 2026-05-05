using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish trade socket update data
    /// </summary>
    public class BullishTradeSocketData
    {
        /// <summary>
        /// ["<c>symbol</c>"] Market symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>trades</c>"] Trades
        /// </summary>
        [JsonPropertyName("trades")]
        public BullishTrade[] Trades { get; set; } = Array.Empty<BullishTrade>();
    }
}
