using CryptoExchange.Net.Interfaces;

namespace Bullish.Net.Objects.Models
{
    /// <summary>
    /// Bullish order book entry
    /// </summary>
    public class BullishOrderBookEntry : ISymbolOrderBookEntry
    {
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public decimal Quantity { get; set; }
    }
}