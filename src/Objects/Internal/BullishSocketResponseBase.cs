using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Internal
{
    /// <summary>
    /// Bullish socket response base
    /// </summary>
    internal abstract class BullishSocketResponseBase
    {
        /// <summary>
        /// ["<c>id</c>"] Request id
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}