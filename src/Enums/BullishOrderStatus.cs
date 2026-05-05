using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishOrderStatus>))]
    public enum BullishOrderStatus
    {
        /// <summary>
        /// ["<c>OPEN</c>"] Open
        /// </summary>
        [Map("OPEN")]
        Open,

        /// <summary>
        /// ["<c>CLOSED</c>"] Closed
        /// </summary>
        [Map("CLOSED")]
        Closed,

        /// <summary>
        /// ["<c>CANCELLED</c>"] Cancelled
        /// </summary>
        [Map("CANCELLED")]
        Cancelled,

        /// <summary>
        /// ["<c>REJECTED</c>"] Rejected
        /// </summary>
        [Map("REJECTED")]
        Rejected
    }
}