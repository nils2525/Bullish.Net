using System.Text.Json.Serialization;
using Bullish.Net.Enums;

namespace Bullish.Net.Objects.Internal
{
    internal class BullishSubscriptionEvent<T>
    {
        [JsonPropertyName("dataType")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public BullishSocketAction Action { get; set; } = BullishSocketAction.Update;

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
