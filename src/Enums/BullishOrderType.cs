using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<BullishOrderType>))]
    public enum BullishOrderType
    {
        [Map("LMT")]
        Limit,

        [Map("MKT")]
        Market,

        [Map("STOP_LIMIT")]
        StopLimit,

        [Map("POST_ONLY")]
        PostOnly,
    }
}
