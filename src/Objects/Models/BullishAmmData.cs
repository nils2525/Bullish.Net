using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish AMM ticker data
    /// </summary>
    public class BullishAmmData
    {
        /// <summary>
        /// ["<c>feeTierId</c>"] Fee tier id
        /// </summary>
        [JsonPropertyName("feeTierId")]
        public int FeeTierId { get; set; }

        /// <summary>
        /// ["<c>tierPrice</c>"] Tier price
        /// </summary>
        [JsonPropertyName("tierPrice")]
        public decimal TierPrice { get; set; }

        /// <summary>
        /// ["<c>currentPrice</c>"] Current price
        /// </summary>
        [JsonPropertyName("currentPrice")]
        public decimal CurrentPrice { get; set; }

        /// <summary>
        /// ["<c>bidSpreadFee</c>"] Bid spread fee
        /// </summary>
        [JsonPropertyName("bidSpreadFee")]
        public decimal BidSpreadFee { get; set; }

        /// <summary>
        /// ["<c>askSpreadFee</c>"] Ask spread fee
        /// </summary>
        [JsonPropertyName("askSpreadFee")]
        public decimal AskSpreadFee { get; set; }
    }
}