using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish order update from websocket
    /// </summary>
    public class BullishOrderUpdate
    {
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
        /// Order type
        /// </summary>
        [JsonPropertyName("type")]
        public BullishOrderType Type { get; set; }

        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side")]
        public BullishTradeSide Side { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Filled quantity
        /// </summary>
        [JsonPropertyName("filledQuantity")]
        public decimal FilledQuantity { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [JsonPropertyName("status")]
        public BullishOrderState Status { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("datetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
