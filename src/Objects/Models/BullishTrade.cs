using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using Bullish.Net.Objects.Internal;

namespace Bullish.Net.Objects.Models
{
    public class BullishTrade : BullishSocketDataWithSymbolPublishCreateTimestamp
    {
        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        [JsonPropertyName("side")]
        public BullishTradeSide Side { get; set; }

        [JsonPropertyName("isTaker")]
        public bool IsTaker { get; set; }
    }
}
