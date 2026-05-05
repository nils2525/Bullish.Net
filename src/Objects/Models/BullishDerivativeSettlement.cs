using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish derivative settlement history entry
    /// </summary>
    public class BullishDerivativeSettlement
    {
        /// <summary>
        /// ["<c>tradingAccountId</c>"] Trading account id
        /// </summary>
        [JsonPropertyName("tradingAccountId")]
        public string TradingAccountId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>symbol</c>"] Market symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>side</c>"] Position side
        /// </summary>
        [JsonPropertyName("side")]
        public BullishTradeSide Side { get; set; }

        /// <summary>
        /// ["<c>settlementQuantity</c>"] Settlement quantity
        /// </summary>
        [JsonPropertyName("settlementQuantity")]
        public decimal SettlementQuantity { get; set; }

        /// <summary>
        /// ["<c>deltaTradingQuantity</c>"] Delta trading quantity
        /// </summary>
        [JsonPropertyName("deltaTradingQuantity")]
        public decimal DeltaTradingQuantity { get; set; }

        /// <summary>
        /// ["<c>mtmPnl</c>"] Mark-to-market profit and loss
        /// </summary>
        [JsonPropertyName("mtmPnl")]
        public decimal? MtmPnl { get; set; }

        /// <summary>
        /// ["<c>mtmPnlUsdc</c>"] Mark-to-market profit and loss in USDC
        /// </summary>
        [JsonPropertyName("mtmPnlUsdc")]
        public decimal? MtmPnlUsdc { get; set; }

        /// <summary>
        /// ["<c>fundingPnl</c>"] Funding profit and loss
        /// </summary>
        [JsonPropertyName("fundingPnl")]
        public decimal? FundingPnl { get; set; }

        /// <summary>
        /// ["<c>fundingPnlUsdc</c>"] Funding profit and loss in USDC
        /// </summary>
        [JsonPropertyName("fundingPnlUsdc")]
        public decimal? FundingPnlUsdc { get; set; }

        /// <summary>
        /// ["<c>eventType</c>"] Settlement event type
        /// </summary>
        [JsonPropertyName("eventType")]
        public string? EventType { get; set; }

        /// <summary>
        /// ["<c>settlementMarkPrice</c>"] Settlement mark price
        /// </summary>
        [JsonPropertyName("settlementMarkPrice")]
        public decimal? SettlementMarkPrice { get; set; }

        /// <summary>
        /// ["<c>settlementMarkPriceUsdc</c>"] Settlement mark price in USDC
        /// </summary>
        [JsonPropertyName("settlementMarkPriceUsdc")]
        public decimal? SettlementMarkPriceUsdc { get; set; }

        /// <summary>
        /// ["<c>settlementIndexPrice</c>"] Settlement index price
        /// </summary>
        [JsonPropertyName("settlementIndexPrice")]
        public decimal? SettlementIndexPrice { get; set; }

        /// <summary>
        /// ["<c>settlementIndexPriceUsdc</c>"] Settlement index price in USDC
        /// </summary>
        [JsonPropertyName("settlementIndexPriceUsdc")]
        public decimal? SettlementIndexPriceUsdc { get; set; }

        /// <summary>
        /// ["<c>settlementFundingRate</c>"] Settlement funding rate
        /// </summary>
        [JsonPropertyName("settlementFundingRate")]
        public decimal? SettlementFundingRate { get; set; }

        /// <summary>
        /// ["<c>settlementDatetime</c>"] Settlement time
        /// </summary>
        [JsonPropertyName("settlementDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime SettlementTime { get; set; }

        /// <summary>
        /// ["<c>settlementTimestamp</c>"] Settlement timestamp
        /// </summary>
        [JsonPropertyName("settlementTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime SettlementTimestamp { get; set; }
    }
}