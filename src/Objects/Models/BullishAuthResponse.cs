using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish authentication response
    /// </summary>
    public class BullishAuthResponse
    {
        /// <summary>
        /// ["<c>authorizer</c>"] Authorizer used for signing requests
        /// </summary>
        [JsonPropertyName("authorizer")]
        public string Authorizer { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>token</c>"] JWT token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;
    }
}
