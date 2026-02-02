using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    public class BullishSymbol
    {
        [JsonPropertyName("marketId")]
        public string SymbolId { get; set; } = string.Empty;

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("baseSymbol")]
        public string? BaseAsset { get; set; } = string.Empty;

        [JsonPropertyName("underlyingBaseSymbol")]
        public string? UnderlyingBaseAsset { get; set; } = string.Empty;

        [JsonPropertyName("quoteSymbol")]
        public string? QuoteAsset { get; set; } = string.Empty;

        [JsonPropertyName("underlyingQuoteSymbol")]
        public string? UnderlyingQuoteAsset { get; set; } = string.Empty;

        [JsonPropertyName("baseAssetId")]
        public string? BaseAssetId { get; set; } = string.Empty;

        [JsonPropertyName("quoteAssetId")]
        public string? QuoteAssetId { get; set; } = string.Empty;

        [JsonPropertyName("quotePrecision")]
        public int QuotePrecision { get; set; }

        [JsonPropertyName("basePrecision")]
        public int BasePrecision { get; set; }

        [JsonPropertyName("pricePrecision")]
        public int PricePrecision { get; set; }

        [JsonPropertyName("costPrecision")]
        public int CostPrecision { get; set; }

        [JsonPropertyName("priceBuffer")]
        public decimal PriceBuffer { get; set; }

        [JsonPropertyName("minQuantityLimit")]
        public decimal? MinQuantityLimit { get; set; }

        [JsonPropertyName("maxQuantityLimit")]
        public decimal? MaxQuantityLimit { get; set; }

        [JsonPropertyName("minPriceLimit")]
        public decimal? MinPriceLimit { get; set; }

        [JsonPropertyName("maxPriceLimit")]
        public decimal? MaxPriceLimit { get; set; }

        [JsonPropertyName("minCostLimit")]
        public decimal? MinCostLimit { get; set; }

        [JsonPropertyName("maxCostLimit")]
        public decimal? MaxCostLimit { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; } = string.Empty;

        [JsonPropertyName("tickSize")]
        public decimal TickSize { get; set; }

        [JsonPropertyName("liquidityTickSize")]
        public decimal LiquidityTickSize { get; set; }

        [JsonPropertyName("loquidityPrecision")]
        public int LiquidityPrecision { get; set; }

        [JsonPropertyName("makerFee")]
        public decimal MakerFee { get; set; }

        [JsonPropertyName("takerFee")]
        public decimal TakerFee { get; set; }

        [JsonPropertyName("roundingCorrectionFactor")]
        public decimal RoundingCorrectionFactor { get; set; }

        [JsonPropertyName("makerMinLiquidityAddition")]
        public decimal MakerMinLiquidityAddition { get; set; }

        [JsonPropertyName("orderTypes")]
        public BullishOrderType[] OrderTypes { get; set; } = Array.Empty<BullishOrderType>();

        [JsonPropertyName("spotTradingEnabled")]
        public bool SpotTradingEnabled { get; set; }

        [JsonPropertyName("marginTradingEnabled")]
        public bool MarginTradingEnabled { get; set; }

        [JsonPropertyName("marketEnabled")]
        public bool MarketEnabled { get; set; }

        [JsonPropertyName("createOrderEnabled")]
        public bool CreateOrderEnabled { get; set; }

        [JsonPropertyName("cancelOrderEnabled")]
        public bool CancelOrderEnabled { get; set; }

        [JsonPropertyName("liquidityInvestEnabled")]
        public bool LiquidityInvestEnabled { get; set; }

        [JsonPropertyName("marketType")]
        public BullishSymbolType Type { get; set; }

        [JsonPropertyName("contractMultiplier")]
        public decimal ContractMultiplier { get; set; }

        [JsonPropertyName("settlementAssetSymbol")]
        public string? SettlementAssetSymbol { get; set; } = string.Empty;

        [JsonPropertyName("openInterestUSD")]
        public decimal? OpenInterestUSD { get; set; }

        [JsonPropertyName("concentrationRiskThresholdUSD")]
        public decimal? ConcentrationRiskThresholdUSD { get; set; }

        [JsonPropertyName("concentrationRiskPercentage")]
        public decimal? ConcentrationRiskPercentage { get; set; }

        [JsonPropertyName("expiryDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? ExpiryDatetime { get; set; }
    }
}

