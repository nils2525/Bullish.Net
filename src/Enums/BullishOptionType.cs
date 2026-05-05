using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Option type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishOptionType>))]
    public enum BullishOptionType
    {
        /// <summary>
        /// ["<c>CALL</c>"] Call option
        /// </summary>
        [Map("CALL")]
        Call,

        /// <summary>
        /// ["<c>PUT</c>"] Put option
        /// </summary>
        [Map("PUT")]
        Put
    }
}