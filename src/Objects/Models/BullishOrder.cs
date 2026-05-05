using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish order information
    /// </summary>
    public class BullishOrder
    {
        /// <summary>
        /// ["<c>handle</c>"] Order handle
        /// </summary>
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        /// <summary>
        /// ["<c>clientOrderId</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOrderId")]
        public string? ClientOrderId { get; set; }

        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>symbol</c>"] Market symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>price</c>"] Order price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// ["<c>averageFillPrice</c>"] Average fill price
        /// </summary>
        [JsonPropertyName("averageFillPrice")]
        public decimal? AverageFillPrice { get; set; }

        /// <summary>
        /// ["<c>stopPrice</c>"] Stop price
        /// </summary>
        [JsonPropertyName("stopPrice")]
        public decimal? StopPrice { get; set; }

        /// <summary>
        /// ["<c>margin</c>"] Whether the order uses margin
        /// </summary>
        [JsonPropertyName("margin")]
        public bool? Margin { get; set; }

        /// <summary>
        /// ["<c>allowBorrow</c>"] Whether borrowing is allowed
        /// </summary>
        [JsonPropertyName("allowBorrow")]
        public bool AllowBorrow { get; set; }

        /// <summary>
        /// ["<c>quantity</c>"] Order quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// ["<c>quantityFilled</c>"] Filled quantity
        /// </summary>
        [JsonPropertyName("quantityFilled")]
        public decimal QuantityFilled { get; set; }

        /// <summary>
        /// ["<c>quoteAmount</c>"] Quote amount
        /// </summary>
        [JsonPropertyName("quoteAmount")]
        public decimal? QuoteAmount { get; set; }

        /// <summary>
        /// ["<c>baseFee</c>"] Base asset fee
        /// </summary>
        [JsonPropertyName("baseFee")]
        public decimal BaseFee { get; set; }

        /// <summary>
        /// ["<c>quoteFee</c>"] Quote asset fee
        /// </summary>
        [JsonPropertyName("quoteFee")]
        public decimal QuoteFee { get; set; }

        /// <summary>
        /// ["<c>borrowedBaseQuantity</c>"] Borrowed base quantity
        /// </summary>
        [JsonPropertyName("borrowedBaseQuantity")]
        public decimal? BorrowedBaseQuantity { get; set; }

        /// <summary>
        /// ["<c>borrowedQuoteQuantity</c>"] Borrowed quote quantity
        /// </summary>
        [JsonPropertyName("borrowedQuoteQuantity")]
        public decimal? BorrowedQuoteQuantity { get; set; }

        /// <summary>
        /// ["<c>borrowedQuantity</c>"] Borrowed quantity
        /// </summary>
        [JsonPropertyName("borrowedQuantity")]
        public decimal? BorrowedQuantity { get; set; }

        /// <summary>
        /// ["<c>isLiquidation</c>"] Whether the order is a liquidation order
        /// </summary>
        [JsonPropertyName("isLiquidation")]
        public bool IsLiquidation { get; set; }

        /// <summary>
        /// ["<c>side</c>"] Order side
        /// </summary>
        [JsonPropertyName("side")]
        public BullishTradeSide Side { get; set; }

        /// <summary>
        /// ["<c>type</c>"] Order type
        /// </summary>
        [JsonPropertyName("type")]
        public BullishOrderType Type { get; set; }

        /// <summary>
        /// ["<c>timeInForce</c>"] Time in force
        /// </summary>
        [JsonPropertyName("timeInForce")]
        public BullishTimeInForce? TimeInForce { get; set; }

        /// <summary>
        /// ["<c>status</c>"] Order status
        /// </summary>
        [JsonPropertyName("status")]
        public BullishOrderStatus Status { get; set; }

        /// <summary>
        /// ["<c>statusReason</c>"] Order status reason
        /// </summary>
        [JsonPropertyName("statusReason")]
        public string? StatusReason { get; set; }

        /// <summary>
        /// ["<c>statusReasonCode</c>"] Order status reason code
        /// </summary>
        [JsonPropertyName("statusReasonCode")]
        [JsonConverter(typeof(NumberStringConverter))]
        public string? StatusReasonCode { get; set; }

        /// <summary>
        /// ["<c>createdAtDatetime</c>"] Order creation time
        /// </summary>
        [JsonPropertyName("createdAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ["<c>createdAtTimestamp</c>"] Order creation timestamp
        /// </summary>
        [JsonPropertyName("createdAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAtTimestamp { get; set; }

        /// <summary>
        /// ["<c>publishedAtTimestamp</c>"] Socket publish timestamp
        /// </summary>
        [JsonPropertyName("publishedAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? PublishedAtTimestamp { get; set; }
    }
}