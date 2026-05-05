using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish user trade information
    /// </summary>
    public class BullishUserTrade
    {
        /// <summary>
        /// ["<c>tradeId</c>"] Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;

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
        /// ["<c>symbol</c>"] Market symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

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
        /// ["<c>quoteAmount</c>"] Quote amount
        /// </summary>
        [JsonPropertyName("quoteAmount")]
        public decimal QuoteAmount { get; set; }

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
        /// ["<c>side</c>"] Order side
        /// </summary>
        [JsonPropertyName("side")]
        public BullishTradeSide Side { get; set; }

        /// <summary>
        /// ["<c>tradeRebateAmount</c>"] Trade rebate amount
        /// </summary>
        [JsonPropertyName("tradeRebateAmount")]
        public decimal? TradeRebateAmount { get; set; }

        /// <summary>
        /// ["<c>tradeRebateAssetSymbol</c>"] Trade rebate asset symbol
        /// </summary>
        [JsonPropertyName("tradeRebateAssetSymbol")]
        public string? TradeRebateAsset { get; set; }

        /// <summary>
        /// ["<c>isTaker</c>"] Whether the trade was taker-side
        /// </summary>
        [JsonPropertyName("isTaker")]
        public bool IsTaker { get; set; }

        /// <summary>
        /// ["<c>otcMatchId</c>"] OTC match id
        /// </summary>
        [JsonPropertyName("otcMatchId")]
        public string? OtcMatchId { get; set; }

        /// <summary>
        /// ["<c>otcTradeId</c>"] OTC trade id
        /// </summary>
        [JsonPropertyName("otcTradeId")]
        public string? OtcTradeId { get; set; }

        /// <summary>
        /// ["<c>clientOtcTradeId</c>"] Client OTC trade id
        /// </summary>
        [JsonPropertyName("clientOtcTradeId")]
        public string? ClientOtcTradeId { get; set; }

        /// <summary>
        /// ["<c>createdAtDatetime</c>"] Trade creation time
        /// </summary>
        [JsonPropertyName("createdAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ["<c>createdAtTimestamp</c>"] Trade creation timestamp
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