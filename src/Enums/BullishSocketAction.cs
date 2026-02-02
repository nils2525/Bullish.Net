using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<BullishSocketAction>))]
    public enum BullishSocketAction
    {
        [Map("update")]
        Update,

        [Map("snapshot")]
        Snapshot,

        [Map("error")]
        Error
    }
}
