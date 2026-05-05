using System.Text.Json.Serialization;
using Bullish.Net.Enums;
using Bullish.Net.Converters;

namespace Bullish.Net.Objects.Internal
{
    /// <summary>
    /// Bullish subscription event
    /// </summary>
    /// <typeparam name="T">Event data type</typeparam>
    internal class BullishSubscriptionEvent<T>
    {
        /// <summary>
        /// ["<c>dataType</c>"] Data channel
        /// </summary>
        [JsonPropertyName("dataType")]
        public string Channel { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>type</c>"] Event action
        /// </summary>
        [JsonPropertyName("type")]
        public BullishSocketAction Action { get; set; } = BullishSocketAction.Update;

        /// <summary>
        /// ["<c>data</c>"] Event data
        /// </summary>
        [JsonPropertyName("data")]
        [JsonConverter(typeof(BullishObjectToArrayConverter))]
        public T Data { get; set; } = default!;
    }
}
