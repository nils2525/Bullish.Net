using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish pagination links
    /// </summary>
    public class BullishPagedLinks
    {
        /// <summary>
        /// ["<c>previous</c>"] Previous page link
        /// </summary>
        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        /// <summary>
        /// ["<c>next</c>"] Next page link
        /// </summary>
        [JsonPropertyName("next")]
        public string? Next { get; set; }
    }
}