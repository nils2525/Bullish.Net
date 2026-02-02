using System.Text.Json.Serialization;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Objects.Internal
{
    internal class BullishSocketRequest
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = "2.0";

        [JsonPropertyName("type")]
        public string Type { get; set; } = "command";

        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        [JsonPropertyName("params"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ParameterCollection? Parameters { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; } = ExchangeHelpers.NextId().ToString();

        public BullishSocketRequest()
        { }

        public BullishSocketRequest(string method)
        {
            Method = method;
        }
    }
}
