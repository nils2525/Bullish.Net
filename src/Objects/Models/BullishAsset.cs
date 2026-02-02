using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    public class BullishAsset
    {
        [JsonPropertyName("assetId")]
        public string AssetId { get; set; } = string.Empty;

        [JsonPropertyName("symbol")]
        public string Asset { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("precision")]
        public int Precision { get; set; }

        [JsonPropertyName("minBalanceInterest")]
        public decimal MinBalanceInterest { get; set; }

        [JsonPropertyName("minFee")]
        public decimal MinFee { get; set; }

        [JsonPropertyName("apr")]
        public decimal Apr { get; set; }

        [JsonPropertyName("maxBorrow")]
        public decimal MaxBorrow { get; set; }

        [JsonPropertyName("totalOfferedLoanQuantity")]
        public decimal TotalOfferedLoanQuantity { get; set; }

        [JsonPropertyName("loanBorrowedQuantity")]
        public decimal LoanBorrowedQuantity { get; set; }
    }
}
