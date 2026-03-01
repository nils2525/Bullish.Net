using System.Text.Json.Serialization;
using Bullish.Net.Objects.Internal;
using Bullish.Net.Objects.Models;

namespace Bullish.Net.Converters
{
    [JsonSerializable(typeof(BullishAsset[]))]
    [JsonSerializable(typeof(BullishSymbol[]))]
    [JsonSerializable(typeof(BullishTicker[]))]
    [JsonSerializable(typeof(BullishSocketResponse))]
    [JsonSerializable(typeof(BullishSocketRequest))]
    [JsonSerializable(typeof(BullishSubscriptionEvent<BullishTicker>))]
    [JsonSerializable(typeof(BullishSubscriptionEvent<BullishTradeSocketData>))]
    [JsonSerializable(typeof(BullishSubscriptionEvent<BullishOrderBook>))]
    [JsonSerializable(typeof(BullishSubscriptionEvent<BullishOrderUpdate>))]
    [JsonSerializable(typeof(BullishSubscriptionEvent<BullishUserTrade>))]
    [JsonSerializable(typeof(BullishSubscriptionEvent<BullishAssetAccount>))]
    internal partial class BullishSourceGenerationContext : JsonSerializerContext
    { }
}
