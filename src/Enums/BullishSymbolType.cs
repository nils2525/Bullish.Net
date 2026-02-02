using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<BullishSymbolType>))]
    public enum BullishSymbolType
    {
        [Map("SPOT")]
        Spot,

        [Map("PERPETUAL")]
        Perpetual,

        [Map("DATED_FUTURE")]
        DatedFuture,

        [Map("OPTION")]
        Option
    }
}
