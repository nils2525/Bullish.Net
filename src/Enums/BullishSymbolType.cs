using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Market type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishSymbolType>))]
    public enum BullishSymbolType
    {
        /// <summary>
        /// ["<c>SPOT</c>"] Spot market
        /// </summary>
        [Map("SPOT")]
        Spot,

        /// <summary>
        /// ["<c>PERPETUAL</c>"] Perpetual market
        /// </summary>
        [Map("PERPETUAL")]
        Perpetual,

        /// <summary>
        /// ["<c>DATED_FUTURE</c>"] Dated future market
        /// </summary>
        [Map("DATED_FUTURE")]
        DatedFuture,

        /// <summary>
        /// ["<c>OPTION</c>"] Option market
        /// </summary>
        [Map("OPTION")]
        Option
    }
}
