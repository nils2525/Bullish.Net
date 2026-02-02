using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    public class BullishTradeSocketData
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = String.Empty;

        [JsonPropertyName("trades")]
        public BullishTrade[] Trades { get; set; } = Array.Empty<BullishTrade>();
    }
}
