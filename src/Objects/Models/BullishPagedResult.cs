using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish paged result
    /// </summary>
    /// <typeparam name="T">Result data type</typeparam>
    public class BullishPagedResult<T>
    {
        /// <summary>
        /// ["<c>data</c>"] Result data
        /// </summary>
        [JsonPropertyName("data")]
        public T[] Data { get; set; } = Array.Empty<T>();

        /// <summary>
        /// ["<c>links</c>"] Pagination links
        /// </summary>
        [JsonPropertyName("links")]
        public BullishPagedLinks Links { get; set; } = new BullishPagedLinks();

        /// <summary>
        /// ["<c>totalCount</c>"] Total result count
        /// </summary>
        [JsonPropertyName("totalCount")]
        public int? TotalCount { get; set; }
    }
}