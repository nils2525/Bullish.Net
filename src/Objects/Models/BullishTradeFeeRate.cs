using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish trade fee rate
    /// </summary>
    public class BullishTradeFeeRate
    {
        /// <summary>
        /// ["<c>feeGroupId</c>"] Fee group id
        /// </summary>
        [JsonPropertyName("feeGroupId")]
        public int FeeGroupId { get; set; }

        /// <summary>
        /// ["<c>makerFee</c>"] Maker fee
        /// </summary>
        [JsonPropertyName("makerFee")]
        public decimal MakerFee { get; set; }

        /// <summary>
        /// ["<c>takerFee</c>"] Taker fee
        /// </summary>
        [JsonPropertyName("takerFee")]
        public decimal TakerFee { get; set; }

        /// <summary>
        /// ["<c>makerOtcFee</c>"] Maker OTC fee
        /// </summary>
        [JsonPropertyName("makerOtcFee")]
        public decimal? MakerOtcFee { get; set; }

        /// <summary>
        /// ["<c>takerOtcFee</c>"] Taker OTC fee
        /// </summary>
        [JsonPropertyName("takerOtcFee")]
        public decimal? TakerOtcFee { get; set; }

        /// <summary>
        /// ["<c>brokerFee</c>"] Broker fee
        /// </summary>
        [JsonPropertyName("brokerFee")]
        public decimal? BrokerFee { get; set; }
    }
}