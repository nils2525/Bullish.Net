using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Time in force
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishTimeInForce>))]
    public enum BullishTimeInForce
    {
        /// <summary>
        /// ["<c>GTC</c>"] Good till canceled
        /// </summary>
        [Map("GTC")]
        GoodTillCanceled,

        /// <summary>
        /// ["<c>FOK</c>"] Fill or kill
        /// </summary>
        [Map("FOK")]
        FillOrKill,

        /// <summary>
        /// ["<c>IOC</c>"] Immediate or cancel
        /// </summary>
        [Map("IOC")]
        ImmediateOrCancel
    }
}