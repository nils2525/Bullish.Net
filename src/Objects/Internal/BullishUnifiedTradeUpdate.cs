using System.Text.Json.Serialization;
using Bullish.Net.Objects.Models;

namespace Bullish.Net.Objects.Internal
{
    /// <summary>
    /// Bullish unified trade socket update
    /// </summary>
    internal class BullishUnifiedTradeUpdate : BullishSocketDataWithSymbolPublishCreateTimestamp
    {
        /// <summary>
        /// ["<c>trades</c>"] Trades
        /// </summary>
        [JsonPropertyName("trades")]
        public IEnumerable<BullishTrade> Trades { get; set; } = Enumerable.Empty<BullishTrade>();
    }
}
