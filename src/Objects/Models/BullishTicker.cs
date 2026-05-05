using System.Text.Json.Serialization;
using Bullish.Net.Objects.Internal;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish market tick information
    /// </summary>
    public class BullishTicker : BullishSocketDataWithSymbolPublishCreateTimestamp
    {
        /// <summary>
        /// ["<c>createdAtDatetime</c>"] Time of the current tick
        /// </summary>
        [JsonPropertyName("createdAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// ["<c>high</c>"] Highest price
        /// </summary>
        [JsonPropertyName("high")]
        public decimal? High { get; set; }

        /// <summary>
        /// ["<c>low</c>"] Lowest price
        /// </summary>
        [JsonPropertyName("low")]
        public decimal? Low { get; set; }

        /// <summary>
        /// ["<c>bestBid</c>"] Best bid price
        /// </summary>
        [JsonPropertyName("bestBid")]
        public decimal? BestBid { get; set; }

        /// <summary>
        /// ["<c>bidIVPercentage</c>"] Implied volatility of the best bid price
        /// </summary>
        [JsonPropertyName("bidIVPercentage")]
        public decimal? BidIVPercentage { get; set; }

        /// <summary>
        /// ["<c>bidVolume</c>"] Best bid quantity
        /// </summary>
        [JsonPropertyName("bidVolume")]
        public decimal? BidVolume { get; set; }

        /// <summary>
        /// ["<c>bestAsk</c>"] Best ask price
        /// </summary>
        [JsonPropertyName("bestAsk")]
        public decimal? BestAsk { get; set; }

        /// <summary>
        /// ["<c>askIVPercentage</c>"] Implied volatility of the best ask price
        /// </summary>
        [JsonPropertyName("askIVPercentage")]
        public decimal? AskIVPercentage { get; set; }

        /// <summary>
        /// ["<c>askVolume</c>"] Best ask quantity
        /// </summary>
        [JsonPropertyName("askVolume")]
        public decimal? AskVolume { get; set; }

        /// <summary>
        /// ["<c>vwap</c>"] Volume weighted average price
        /// </summary>
        [JsonPropertyName("vwap")]
        public decimal? Vwap { get; set; }

        /// <summary>
        /// ["<c>open</c>"] Opening price
        /// </summary>
        [JsonPropertyName("open")]
        public decimal? Open { get; set; }

        /// <summary>
        /// ["<c>close</c>"] Closing price
        /// </summary>
        [JsonPropertyName("close")]
        public decimal? Close { get; set; }

        /// <summary>
        /// ["<c>last</c>"] Last traded price
        /// </summary>
        [JsonPropertyName("last")]
        public decimal? LastPrice { get; set; }

        /// <summary>
        /// ["<c>change</c>"] Absolute price change
        /// </summary>
        [JsonPropertyName("change")]
        public decimal? Change { get; set; }

        /// <summary>
        /// ["<c>percentage</c>"] Relative price change percentage
        /// </summary>
        [JsonPropertyName("percentage")]
        public decimal? ChangePercentage { get; set; }

        /// <summary>
        /// ["<c>average</c>"] Average price
        /// </summary>
        [JsonPropertyName("average")]
        public decimal? Average { get; set; }

        /// <summary>
        /// ["<c>baseVolume</c>"] Base asset volume over the last 24 hours
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal? BaseVolume { get; set; }

        /// <summary>
        /// ["<c>quoteVolume</c>"] Quote asset volume over the last 24 hours
        /// </summary>
        [JsonPropertyName("quoteVolume")]
        public decimal? QuoteVolume { get; set; }

        /// <summary>
        /// ["<c>bancorPrice</c>"] Bancor price
        /// </summary>
        [JsonPropertyName("bancorPrice")]
        public decimal? BancorPrice { get; set; }

        /// <summary>
        /// ["<c>markPrice</c>"] Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }

        /// <summary>
        /// ["<c>fundingRate</c>"] Funding rate
        /// </summary>
        [JsonPropertyName("fundingRate")]
        public decimal? FundingRate { get; set; }

        /// <summary>
        /// ["<c>openInterest</c>"] Open interest
        /// </summary>
        [JsonPropertyName("openInterest")]
        public decimal? OpenInterest { get; set; }

        /// <summary>
        /// ["<c>lastTradeDatetime</c>"] Time of the last trade
        /// </summary>
        [JsonPropertyName("lastTradeDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? LastTradeTime { get; set; }

        /// <summary>
        /// ["<c>lastTradeTimestamp</c>"] Timestamp of the last trade
        /// </summary>
        [JsonPropertyName("lastTradeTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? LastTradeTimestamp { get; set; }

        /// <summary>
        /// ["<c>lastTradeQuantity</c>"] Quantity of the last trade
        /// </summary>
        [JsonPropertyName("lastTradeQuantity")]
        public decimal? LastTradeQuantity { get; set; }

        /// <summary>
        /// ["<c>ammData</c>"] AMM data
        /// </summary>
        [JsonPropertyName("ammData")]
        public BullishAmmData[] AmmData { get; set; } = Array.Empty<BullishAmmData>();

        /// <summary>
        /// ["<c>delta</c>"] Option delta
        /// </summary>
        [JsonPropertyName("delta")]
        public decimal? Delta { get; set; }

        /// <summary>
        /// ["<c>gamma</c>"] Option gamma
        /// </summary>
        [JsonPropertyName("gamma")]
        public decimal? Gamma { get; set; }

        /// <summary>
        /// ["<c>theta</c>"] Option theta
        /// </summary>
        [JsonPropertyName("theta")]
        public decimal? Theta { get; set; }

        /// <summary>
        /// ["<c>vega</c>"] Option vega
        /// </summary>
        [JsonPropertyName("vega")]
        public decimal? Vega { get; set; }
    }
}