using System.Text.Json.Serialization;
using Bullish.Net.Objects.Internal;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    public class BullishTicker : BullishSocketDataWithSymbolPublishCreateTimestamp
    {
        [JsonPropertyName("high")]
        public decimal? High { get; set; }

        [JsonPropertyName("low")]
        public decimal? Low { get; set; }

        [JsonPropertyName("bestBid")]
        public decimal BestBid { get; set; }

        [JsonPropertyName("bidVolume")]
        public decimal? BidVolume { get; set; }

        [JsonPropertyName("bestAsk")]
        public decimal BestAsk { get; set; }

        [JsonPropertyName("askVolume")]
        public decimal? AskVolume { get; set; }

        [JsonPropertyName("vwap")]
        public decimal? Vwap { get; set; }

        [JsonPropertyName("open")]
        public decimal? Open { get; set; }

        [JsonPropertyName("close")]
        public decimal? Close { get; set; }

        [JsonPropertyName("last")]
        public decimal? LastPrice { get; set; }

        [JsonPropertyName("change")]
        public decimal Change { get; set; }

        [JsonPropertyName("percentage")]
        public decimal ChangePercentage { get; set; }

        [JsonPropertyName("average")]
        public decimal? Average { get; set; }

        [JsonPropertyName("baseVolume")]
        public decimal BaseVolume { get; set; }

        [JsonPropertyName("quoteVolume")]
        public decimal QuoteVolume { get; set; }

        [JsonPropertyName("bancorPrice")]
        public decimal BancorPrice { get; set; }

        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }

        [JsonPropertyName("fundingRate")]
        public decimal? FundingRate { get; set; }

        [JsonPropertyName("openIntereset")]
        public decimal? OpenInterest { get; set; }

        [JsonPropertyName("lastTradeTimestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastTradeTimestamp { get; set; }

        [JsonPropertyName("lastTradeQuantity")]
        public decimal LastTradeQuantity { get; set; }
    }
}
