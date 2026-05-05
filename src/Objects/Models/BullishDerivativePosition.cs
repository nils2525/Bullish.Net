using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish derivative position
    /// </summary>
    public class BullishDerivativePosition
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
        /// ["<c>quantity</c>"] Position quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// ["<c>notional</c>"] Notional value
        /// </summary>
        [JsonPropertyName("notional")]
        public decimal? Notional { get; set; }

        /// <summary>
        /// ["<c>notionalUsdc</c>"] Notional value in USDC
        /// </summary>
        [JsonPropertyName("notionalUsdc")]
        public decimal? NotionalUsdc { get; set; }

        /// <summary>
        /// ["<c>entryNotional</c>"] Entry notional value
        /// </summary>
        [JsonPropertyName("entryNotional")]
        public decimal? EntryNotional { get; set; }

        /// <summary>
        /// ["<c>entryNotionalUsdc</c>"] Entry notional value in USDC
        /// </summary>
        [JsonPropertyName("entryNotionalUsdc")]
        public decimal? EntryNotionalUsdc { get; set; }

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
        /// ["<c>reportedMtmPnl</c>"] Reported mark-to-market profit and loss
        /// </summary>
        [JsonPropertyName("reportedMtmPnl")]
        public decimal? ReportedMtmPnl { get; set; }

        /// <summary>
        /// ["<c>reportedMtmPnlUsdc</c>"] Reported mark-to-market profit and loss in USDC
        /// </summary>
        [JsonPropertyName("reportedMtmPnlUsdc")]
        public decimal? ReportedMtmPnlUsdc { get; set; }

        /// <summary>
        /// ["<c>reportedFundingPnl</c>"] Reported funding profit and loss
        /// </summary>
        [JsonPropertyName("reportedFundingPnl")]
        public decimal? ReportedFundingPnl { get; set; }

        /// <summary>
        /// ["<c>reportedFundingPnlUsdc</c>"] Reported funding profit and loss in USDC
        /// </summary>
        [JsonPropertyName("reportedFundingPnlUsdc")]
        public decimal? ReportedFundingPnlUsdc { get; set; }

        /// <summary>
        /// ["<c>realizedPnl</c>"] Realized profit and loss
        /// </summary>
        [JsonPropertyName("realizedPnl")]
        public decimal? RealizedPnl { get; set; }

        /// <summary>
        /// ["<c>realizedPnlUsdc</c>"] Realized profit and loss in USDC
        /// </summary>
        [JsonPropertyName("realizedPnlUsdc")]
        public decimal? RealizedPnlUsdc { get; set; }

        /// <summary>
        /// ["<c>settlementAssetSymbol</c>"] Settlement asset symbol
        /// </summary>
        [JsonPropertyName("settlementAssetSymbol")]
        public string? SettlementAsset { get; set; }

        /// <summary>
        /// ["<c>createdAtDatetime</c>"] Position creation time
        /// </summary>
        [JsonPropertyName("createdAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// ["<c>createdAtTimestamp</c>"] Position creation timestamp
        /// </summary>
        [JsonPropertyName("createdAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAtTimestamp { get; set; }

        /// <summary>
        /// ["<c>updatedAtDatetime</c>"] Position update time
        /// </summary>
        [JsonPropertyName("updatedAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// ["<c>updatedAtTimestamp</c>"] Position update timestamp
        /// </summary>
        [JsonPropertyName("updatedAtTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdatedAtTimestamp { get; set; }

        /// <summary>
        /// ["<c>greeks</c>"] Position greeks
        /// </summary>
        [JsonPropertyName("greeks")]
        public BullishPositionGreeks? Greeks { get; set; }
    }
}