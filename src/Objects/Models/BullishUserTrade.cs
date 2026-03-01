using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish user trade
    /// </summary>
    public class BullishUserTrade
    {
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;

        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("clientOrderId")]
        public string? ClientOrderId { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Trade side
        /// </summary>
        [JsonPropertyName("side")]
        public BullishTradeSide Side { get; set; }

        /// <summary>
        /// Trade price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// Fee symbol
        /// </summary>
        [JsonPropertyName("feeSymbol")]
        public string? FeeSymbol { get; set; }

        /// <summary>
        /// Whether the trade was a taker
        /// </summary>
        [JsonPropertyName("isTaker")]
        public bool IsTaker { get; set; }

        /// <summary>
        /// Trading account id
        /// </summary>
        [JsonPropertyName("tradingAccountId")]
        public string? TradingAccountId { get; set; }

        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonPropertyName("datetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
