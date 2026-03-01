using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish candle/kline data
    /// </summary>
    public class BullishCandle
    {
        /// <summary>
        /// Open time
        /// </summary>
        [JsonPropertyName("datetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime OpenTime { get; set; }

        /// <summary>
        /// Open price
        /// </summary>
        [JsonPropertyName("open")]
        public decimal Open { get; set; }

        /// <summary>
        /// High price
        /// </summary>
        [JsonPropertyName("high")]
        public decimal High { get; set; }

        /// <summary>
        /// Low price
        /// </summary>
        [JsonPropertyName("low")]
        public decimal Low { get; set; }

        /// <summary>
        /// Close price
        /// </summary>
        [JsonPropertyName("close")]
        public decimal Close { get; set; }

        /// <summary>
        /// Volume
        /// </summary>
        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }
    }
}
