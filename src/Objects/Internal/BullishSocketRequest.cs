using System.Text.Json.Serialization;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Objects.Internal
{
    /// <summary>
    /// Bullish socket request
    /// </summary>
    internal class BullishSocketRequest
    {
        /// <summary>
        /// ["<c>jsonrpc</c>"] Json RPC version
        /// </summary>
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = "2.0";

        /// <summary>
        /// ["<c>type</c>"] Request type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = "command";

        /// <summary>
        /// ["<c>method</c>"] Request method
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>params</c>"] Request parameters
        /// </summary>
        [JsonPropertyName("params"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ParameterCollection? Parameters { get; set; }

        /// <summary>
        /// ["<c>id</c>"] Request id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = ExchangeHelpers.NextId().ToString();

        /// <summary>
        /// Create a new socket request
        /// </summary>
        public BullishSocketRequest()
        { }

        /// <summary>
        /// Create a new socket request
        /// </summary>
        /// <param name="method">Request method</param>
        public BullishSocketRequest(string method)
        {
            Method = method;
        }
    }
}
