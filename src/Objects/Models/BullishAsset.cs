using System.Text.Json.Serialization;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish asset information
    /// </summary>
    public class BullishAsset
    {
        /// <summary>
        /// ["<c>assetId</c>"] Unique asset id
        /// </summary>
        [JsonPropertyName("assetId")]
        public string AssetId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>symbol</c>"] Asset symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>name</c>"] Asset name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>precision</c>"] Asset precision
        /// </summary>
        [JsonPropertyName("precision")]
        public int Precision { get; set; }

        /// <summary>
        /// ["<c>minBalanceInterest</c>"] Minimum balance for interest
        /// </summary>
        [JsonPropertyName("minBalanceInterest")]
        public decimal MinBalanceInterest { get; set; }

        /// <summary>
        /// ["<c>minFee</c>"] Minimum fee
        /// </summary>
        [JsonPropertyName("minFee")]
        public decimal MinFee { get; set; }

        /// <summary>
        /// ["<c>apr</c>"] Annualized percentage rate
        /// </summary>
        [JsonPropertyName("apr")]
        public decimal Apr { get; set; }

        /// <summary>
        /// ["<c>maxBorrow</c>"] Maximum quantity that can be borrowed
        /// </summary>
        [JsonPropertyName("maxBorrow")]
        public decimal MaxBorrow { get; set; }

        /// <summary>
        /// ["<c>totalOfferedLoanQuantity</c>"] Total loan quantity offered across the exchange
        /// </summary>
        [JsonPropertyName("totalOfferedLoanQuantity")]
        public decimal TotalOfferedLoanQuantity { get; set; }

        /// <summary>
        /// ["<c>loanBorrowedQuantity</c>"] Loan quantity currently borrowed
        /// </summary>
        [JsonPropertyName("loanBorrowedQuantity")]
        public decimal LoanBorrowedQuantity { get; set; }

        /// <summary>
        /// ["<c>collateralBands</c>"] Collateral bands configured for the asset
        /// </summary>
        [JsonPropertyName("collateralBands")]
        public BullishCollateralBand[] CollateralBands { get; set; } = Array.Empty<BullishCollateralBand>();

        /// <summary>
        /// ["<c>underlyingAsset</c>"] Underlying asset information
        /// </summary>
        [JsonPropertyName("underlyingAsset")]
        public BullishUnderlyingAsset? UnderlyingAsset { get; set; }
    }
}