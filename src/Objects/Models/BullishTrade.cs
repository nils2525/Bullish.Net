using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using Bullish.Net.Objects.Internal;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish public trade
    /// </summary>
    public class BullishTrade : BullishSocketDataWithSymbolPublishCreateTimestamp
    {
        /// <summary>
        /// ["<c>tradeId</c>"] Unique trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>price</c>"] Trade price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// ["<c>quantity</c>"] Trade quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// ["<c>side</c>"] Trade side
        /// </summary>
        [JsonPropertyName("side")]
        public BullishTradeSide Side { get; set; }

        /// <summary>
        /// ["<c>isTaker</c>"] Whether the trade was taker-side
        /// </summary>
        [JsonPropertyName("isTaker")]
        public bool IsTaker { get; set; }
    }
}
