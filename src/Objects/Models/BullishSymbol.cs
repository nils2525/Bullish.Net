using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish market information
    /// </summary>
    public class BullishSymbol
    {
        /// <summary>
        /// ["<c>marketId</c>"] Unique market id
        /// </summary>
        [JsonPropertyName("marketId")]
        public string SymbolId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>symbol</c>"] Market symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>baseSymbol</c>"] Base asset symbol, only applicable to spot markets
        /// </summary>
        [JsonPropertyName("baseSymbol")]
        public string? BaseAsset { get; set; }

        /// <summary>
        /// ["<c>underlyingBaseSymbol</c>"] Underlying base asset symbol, only applicable to derivative markets
        /// </summary>
        [JsonPropertyName("underlyingBaseSymbol")]
        public string? UnderlyingBaseAsset { get; set; }

        /// <summary>
        /// ["<c>quoteSymbol</c>"] Quote asset symbol, only applicable to spot markets
        /// </summary>
        [JsonPropertyName("quoteSymbol")]
        public string? QuoteAsset { get; set; }

        /// <summary>
        /// ["<c>underlyingQuoteSymbol</c>"] Underlying quote asset symbol, only applicable to derivative markets
        /// </summary>
        [JsonPropertyName("underlyingQuoteSymbol")]
        public string? UnderlyingQuoteAsset { get; set; }

        /// <summary>
        /// ["<c>baseAssetId</c>"] Base asset id
        /// </summary>
        [JsonPropertyName("baseAssetId")]
        public string BaseAssetId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>quoteAssetId</c>"] Quote asset id
        /// </summary>
        [JsonPropertyName("quoteAssetId")]
        public string QuoteAssetId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>quotePrecision</c>"] Quote precision
        /// </summary>
        [JsonPropertyName("quotePrecision")]
        public int QuotePrecision { get; set; }

        /// <summary>
        /// ["<c>basePrecision</c>"] Base precision
        /// </summary>
        [JsonPropertyName("basePrecision")]
        public int BasePrecision { get; set; }

        /// <summary>
        /// ["<c>pricePrecision</c>"] Price precision
        /// </summary>
        [JsonPropertyName("pricePrecision")]
        public int PricePrecision { get; set; }

        /// <summary>
        /// ["<c>quantityPrecision</c>"] Quantity precision
        /// </summary>
        [JsonPropertyName("quantityPrecision")]
        public int QuantityPrecision { get; set; }

        /// <summary>
        /// ["<c>costPrecision</c>"] Cost precision
        /// </summary>
        [JsonPropertyName("costPrecision")]
        public int CostPrecision { get; set; }

        /// <summary>
        /// ["<c>priceBuffer</c>"] Buffer range of limit price from the last traded price
        /// </summary>
        [JsonPropertyName("priceBuffer")]
        public decimal? PriceBuffer { get; set; }

        /// <summary>
        /// ["<c>minQuantityLimit</c>"] Minimum order quantity
        /// </summary>
        [JsonPropertyName("minQuantityLimit")]
        public decimal MinQuantityLimit { get; set; }

        /// <summary>
        /// ["<c>maxQuantityLimit</c>"] Maximum order quantity
        /// </summary>
        [JsonPropertyName("maxQuantityLimit")]
        public decimal MaxQuantityLimit { get; set; }

        /// <summary>
        /// ["<c>minPriceLimit</c>"] Minimum order price
        /// </summary>
        [JsonPropertyName("minPriceLimit")]
        public decimal MinPriceLimit { get; set; }

        /// <summary>
        /// ["<c>maxPriceLimit</c>"] Maximum order price
        /// </summary>
        [JsonPropertyName("maxPriceLimit")]
        public decimal MaxPriceLimit { get; set; }

        /// <summary>
        /// ["<c>minCostLimit</c>"] Minimum order cost
        /// </summary>
        [JsonPropertyName("minCostLimit")]
        public decimal MinCostLimit { get; set; }

        /// <summary>
        /// ["<c>maxCostLimit</c>"] Maximum order cost
        /// </summary>
        [JsonPropertyName("maxCostLimit")]
        public decimal MaxCostLimit { get; set; }

        /// <summary>
        /// ["<c>timeZone</c>"] Time zone
        /// </summary>
        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>tickSize</c>"] Tick size
        /// </summary>
        [JsonPropertyName("tickSize")]
        public decimal TickSize { get; set; }

        /// <summary>
        /// ["<c>liquidityTickSize</c>"] Liquidity tick size
        /// </summary>
        [JsonPropertyName("liquidityTickSize")]
        public decimal? LiquidityTickSize { get; set; }

        /// <summary>
        /// ["<c>liquidityPrecision</c>"] Liquidity precision
        /// </summary>
        [JsonPropertyName("liquidityPrecision")]
        public int? LiquidityPrecision { get; set; }

        /// <summary>
        /// ["<c>roundingCorrectionFactor</c>"] Rounding correction factor for the market
        /// </summary>
        [JsonPropertyName("roundingCorrectionFactor")]
        public decimal RoundingCorrectionFactor { get; set; }

        /// <summary>
        /// ["<c>feeGroupId</c>"] Trade fee group id
        /// </summary>
        [JsonPropertyName("feeGroupId")]
        public int FeeGroupId { get; set; }

        /// <summary>
        /// ["<c>makerMinLiquidityAddition</c>"] Minimum amount required to invest liquidity to the market
        /// </summary>
        [JsonPropertyName("makerMinLiquidityAddition")]
        public decimal? MakerMinLiquidityAddition { get; set; }

        /// <summary>
        /// ["<c>orderTypes</c>"] Supported order types
        /// </summary>
        [JsonPropertyName("orderTypes")]
        public BullishOrderType[] OrderTypes { get; set; } = Array.Empty<BullishOrderType>();

        /// <summary>
        /// ["<c>spotTradingEnabled</c>"] Whether spot trading is enabled
        /// </summary>
        [JsonPropertyName("spotTradingEnabled")]
        public bool SpotTradingEnabled { get; set; }

        /// <summary>
        /// ["<c>marginTradingEnabled</c>"] Whether margin trading is enabled
        /// </summary>
        [JsonPropertyName("marginTradingEnabled")]
        public bool MarginTradingEnabled { get; set; }

        /// <summary>
        /// ["<c>marketEnabled</c>"] Whether the market is enabled
        /// </summary>
        [JsonPropertyName("marketEnabled")]
        public bool MarketEnabled { get; set; }

        /// <summary>
        /// ["<c>createOrderEnabled</c>"] Whether order creation is enabled
        /// </summary>
        [JsonPropertyName("createOrderEnabled")]
        public bool CreateOrderEnabled { get; set; }

        /// <summary>
        /// ["<c>cancelOrderEnabled</c>"] Whether order cancellation is enabled
        /// </summary>
        [JsonPropertyName("cancelOrderEnabled")]
        public bool CancelOrderEnabled { get; set; }

        /// <summary>
        /// ["<c>liquidityInvestEnabled</c>"] Whether liquidity investment is enabled
        /// </summary>
        [JsonPropertyName("liquidityInvestEnabled")]
        public bool? LiquidityInvestEnabled { get; set; }

        /// <summary>
        /// ["<c>liquidityWithdrawEnabled</c>"] Whether liquidity withdrawal is enabled
        /// </summary>
        [JsonPropertyName("liquidityWithdrawEnabled")]
        public bool? LiquidityWithdrawEnabled { get; set; }

        /// <summary>
        /// ["<c>feeTiers</c>"] Fee tiers configured for the market
        /// </summary>
        [JsonPropertyName("feeTiers")]
        public BullishFeeTier[] FeeTiers { get; set; } = Array.Empty<BullishFeeTier>();

        /// <summary>
        /// ["<c>marketType</c>"] Market type
        /// </summary>
        [JsonPropertyName("marketType")]
        public BullishSymbolType Type { get; set; }

        /// <summary>
        /// ["<c>contractMultiplier</c>"] Contract multiplier, only applicable to perpetual markets
        /// </summary>
        [JsonPropertyName("contractMultiplier")]
        public int? ContractMultiplier { get; set; }

        /// <summary>
        /// ["<c>settlementAssetSymbol</c>"] Settlement asset symbol, only applicable to perpetual markets
        /// </summary>
        [JsonPropertyName("settlementAssetSymbol")]
        public string? SettlementAssetSymbol { get; set; }

        /// <summary>
        /// ["<c>openInterestUSD</c>"] Cumulative notional value of open interest for the derivative contract
        /// </summary>
        [JsonPropertyName("openInterestUSD")]
        public decimal? OpenInterestUSD { get; set; }

        /// <summary>
        /// ["<c>concentrationRiskThresholdUSD</c>"] Concentration risk threshold in USD
        /// </summary>
        [JsonPropertyName("concentrationRiskThresholdUSD")]
        public decimal? ConcentrationRiskThresholdUSD { get; set; }

        /// <summary>
        /// ["<c>concentrationRiskPercentage</c>"] Concentration risk percentage
        /// </summary>
        [JsonPropertyName("concentrationRiskPercentage")]
        public decimal? ConcentrationRiskPercentage { get; set; }

        /// <summary>
        /// ["<c>expiryDatetime</c>"] Market expiry time
        /// </summary>
        [JsonPropertyName("expiryDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? ExpiryTime { get; set; }

        /// <summary>
        /// ["<c>optionStrikePrice</c>"] Option strike price
        /// </summary>
        [JsonPropertyName("optionStrikePrice")]
        public decimal? OptionStrikePrice { get; set; }

        /// <summary>
        /// ["<c>optionType</c>"] Option type
        /// </summary>
        [JsonPropertyName("optionType")]
        public BullishOptionType? OptionType { get; set; }

        /// <summary>
        /// ["<c>premiumCapRatio</c>"] Option premium cap ratio
        /// </summary>
        [JsonPropertyName("premiumCapRatio")]
        public decimal? PremiumCapRatio { get; set; }
    }
}