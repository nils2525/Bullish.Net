using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    public class BullishAuthResponse
    {
        [JsonPropertyName("authorizer")]
        public string Authorizer { get; set; } = string.Empty;

        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;
    }
}
