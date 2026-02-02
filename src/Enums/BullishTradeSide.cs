using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<BullishTradeSide>))]
    public enum BullishTradeSide
    {
        [Map("BUY")]
        Buy,

        [Map("SELL")]
        Sell
    }
}
