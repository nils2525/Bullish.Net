using System.Text.Json.Serialization;
using Bullish.Net.Objects.Models;

namespace Bullish.Net.Objects.Internal
{
    internal class BullishUnifiedTradeUpdate : BullishSocketDataWithSymbolPublishCreateTimestamp
    {
        [JsonPropertyName("trades")]
        public IEnumerable<BullishTrade> Trades { get; set; } = Enumerable.Empty<BullishTrade>();
    }
}
