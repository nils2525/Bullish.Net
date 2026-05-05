using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Socket update action
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishSocketAction>))]
    public enum BullishSocketAction
    {
        /// <summary>
        /// ["<c>update</c>"] Update
        /// </summary>
        [Map("update")]
        Update,

        /// <summary>
        /// ["<c>snapshot</c>"] Snapshot
        /// </summary>
        [Map("snapshot")]
        Snapshot,

        /// <summary>
        /// ["<c>error</c>"] Error
        /// </summary>
        [Map("error")]
        Error
    }
}
