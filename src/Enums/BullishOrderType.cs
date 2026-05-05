using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Order type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishOrderType>))]
    public enum BullishOrderType
    {
        /// <summary>
        /// ["<c>LIMIT</c>"] Limit order
        /// </summary>
        [Map("LIMIT", "LMT")]
        Limit,

        /// <summary>
        /// ["<c>MARKET</c>"] Market order
        /// </summary>
        [Map("MARKET", "MKT")]
        Market,

        /// <summary>
        /// ["<c>STOP_LIMIT</c>"] Stop limit order
        /// </summary>
        [Map("STOP_LIMIT")]
        StopLimit,

        /// <summary>
        /// ["<c>POST_ONLY</c>"] Post only order
        /// </summary>
        [Map("POST_ONLY")]
        PostOnly,
    }
}
