using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Internal
{
    internal class BullishSocketResponse : BullishSocketResponseBase
    {
        [JsonPropertyName("result")]
        public BullishSubscriptionResult? Result { get; set; }

        [JsonPropertyName("error")]
        public BullishError? Error { get; set; }
    }

    internal abstract class BullishSocketResponseBase
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }

    internal class BullishSubscriptionResult
    {
        [JsonPropertyName("responseCode")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("responseCodeName")]
        public string ResponseCodeName { get; set; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }

    internal class BullishError
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("errorCode")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("errorCodeName")]
        public string ErrorCodeName { get; set; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}