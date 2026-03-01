using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish AMM instruction
    /// </summary>
    public class BullishAmmInstruction
    {
        /// <summary>
        /// Instruction id
        /// </summary>
        [JsonPropertyName("instructionId")]
        public string InstructionId { get; set; } = string.Empty;

        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Base quantity
        /// </summary>
        [JsonPropertyName("baseQuantity")]
        public decimal? BaseQuantity { get; set; }

        /// <summary>
        /// Quote quantity
        /// </summary>
        [JsonPropertyName("quoteQuantity")]
        public decimal? QuoteQuantity { get; set; }

        /// <summary>
        /// Lower bound
        /// </summary>
        [JsonPropertyName("lowerBound")]
        public decimal? LowerBound { get; set; }

        /// <summary>
        /// Upper bound
        /// </summary>
        [JsonPropertyName("upperBound")]
        public decimal? UpperBound { get; set; }

        /// <summary>
        /// Trading account id
        /// </summary>
        [JsonPropertyName("tradingAccountId")]
        public string? TradingAccountId { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        [JsonPropertyName("createdAtDatetime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt { get; set; }
    }
}
