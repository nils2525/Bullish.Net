using System.Text.Json.Serialization;
using Bullish.Net.Objects.Internal;
using Bullish.Net.Objects.Models;

namespace Bullish.Net.Converters
{
    [JsonSerializable(typeof(BullishAsset[]))]
    [JsonSerializable(typeof(BullishAsset))]
    [JsonSerializable(typeof(BullishSymbol[]))]
    [JsonSerializable(typeof(BullishSymbol))]
    [JsonSerializable(typeof(BullishTicker[]))]
    [JsonSerializable(typeof(BullishTicker))]
    [JsonSerializable(typeof(BullishTrade[]))]
    [JsonSerializable(typeof(BullishOrderBook))]
    [JsonSerializable(typeof(BullishCandle[]))]
    [JsonSerializable(typeof(BullishOrder[]))]
    [JsonSerializable(typeof(BullishOrder))]
    [JsonSerializable(typeof(BullishUserTrade[]))]
    [JsonSerializable(typeof(BullishUserTrade))]
    [JsonSerializable(typeof(BullishAssetAccount[]))]
    [JsonSerializable(typeof(BullishAssetAccount))]
    [JsonSerializable(typeof(BullishTradingAccount[]))]
    [JsonSerializable(typeof(BullishTradingAccount))]
    [JsonSerializable(typeof(BullishNonce))]
    [JsonSerializable(typeof(BullishAuthResponse))]
    [JsonSerializable(typeof(BullishTimestamp))]
    [JsonSerializable(typeof(BullishAmmInstruction[]))]
    [JsonSerializable(typeof(BullishAmmInstruction))]
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
