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
        /// Good till cancel
        /// </summary>
        [Map("GTC")]
        GoodTillCancel,

        /// <summary>
        /// Immediate or cancel
        /// </summary>
        [Map("IOC")]
        ImmediateOrCancel,

        /// <summary>
        /// Fill or kill
        /// </summary>
        [Map("FOK")]
        FillOrKill,

        /// <summary>
        /// Good till date
        /// </summary>
        [Map("GTD")]
        GoodTillDate
    }
}
