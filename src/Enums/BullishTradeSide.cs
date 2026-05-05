using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Trade side
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishTradeSide>))]
    public enum BullishTradeSide
    {
        /// <summary>
        /// ["<c>BUY</c>"] Buy
        /// </summary>
        [Map("BUY")]
        Buy,

        /// <summary>
        /// ["<c>SELL</c>"] Sell
        /// </summary>
        [Map("SELL")]
        Sell
    }
}
