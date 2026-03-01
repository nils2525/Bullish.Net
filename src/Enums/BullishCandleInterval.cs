using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Candle interval
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishCandleInterval>))]
    public enum BullishCandleInterval
    {
        /// <summary>
        /// 1 minute
        /// </summary>
        [Map("1m")]
        OneMinute,

        /// <summary>
        /// 5 minutes
        /// </summary>
        [Map("5m")]
        FiveMinutes,

        /// <summary>
        /// 15 minutes
        /// </summary>
        [Map("15m")]
        FifteenMinutes,

        /// <summary>
        /// 30 minutes
        /// </summary>
        [Map("30m")]
        ThirtyMinutes,

        /// <summary>
        /// 1 hour
        /// </summary>
        [Map("1h")]
        OneHour,

        /// <summary>
        /// 2 hours
        /// </summary>
        [Map("2h")]
        TwoHours,

        /// <summary>
        /// 4 hours
        /// </summary>
        [Map("4h")]
        FourHours,

        /// <summary>
        /// 6 hours
        /// </summary>
        [Map("6h")]
        SixHours,

        /// <summary>
        /// 12 hours
        /// </summary>
        [Map("12h")]
        TwelveHours,

        /// <summary>
        /// 1 day
        /// </summary>
        [Map("1d")]
        OneDay
    }
}
