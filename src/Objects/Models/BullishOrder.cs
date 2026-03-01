using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish order
    /// </summary>
    public class BullishOrder
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
        /// Stop price
        /// </summary>
        [JsonPropertyName("stopPrice")]
        public decimal? StopPrice { get; set; }

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
        /// Filled cost
        /// </summary>
        [JsonPropertyName("filledCost")]
        public decimal FilledCost { get; set; }

        /// <summary>
        /// Time in force
        /// </summary>
        [JsonPropertyName("timeInForce")]
        public BullishTimeInForce? TimeInForce { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [JsonPropertyName("status")]
        public BullishOrderState Status { get; set; }

        /// <summary>
        /// Trading account id
        /// </summary>
        [JsonPropertyName("tradingAccountId")]
        public string? TradingAccountId { get; set; }

        /// <summary>
        /// Created at timestamp
        /// </summary>
        [JsonPropertyName("createdAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Updated at timestamp
        /// </summary>
        [JsonPropertyName("updatedAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Average fill price
        /// </summary>
        [JsonPropertyName("averagePrice")]
        public decimal? AveragePrice { get; set; }

        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonPropertyName("totalFees")]
        public decimal? TotalFees { get; set; }

        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("feeSymbol")]
        public string? FeeSymbol { get; set; }
    }
}
