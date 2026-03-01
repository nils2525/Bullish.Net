using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Order state
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishOrderState>))]
    public enum BullishOrderState
    {
        /// <summary>
        /// Order is pending
        /// </summary>
        [Map("PENDING")]
        Pending,

        /// <summary>
        /// Order is open
        /// </summary>
        [Map("OPEN")]
        Open,

        /// <summary>
        /// Order is partially filled
        /// </summary>
        [Map("PARTIALLY_FILLED")]
        PartiallyFilled,

        /// <summary>
        /// Order is fully filled
        /// </summary>
        [Map("FILLED")]
        Filled,

        /// <summary>
        /// Order is cancelled
        /// </summary>
        [Map("CANCELLED")]
        Cancelled,

        /// <summary>
        /// Order is rejected
        /// </summary>
        [Map("REJECTED")]
        Rejected,

        /// <summary>
        /// Order is expired
        /// </summary>
        [Map("EXPIRED")]
        Expired
    }
}
