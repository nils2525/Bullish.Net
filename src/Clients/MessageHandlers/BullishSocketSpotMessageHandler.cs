using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bullish.Net.Objects.Internal;
using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;

namespace Bullish.Net.Clients.MessageHandlers
{
    internal class BullishSocketSpotMessageHandler : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BullishExchange.SerializerContext);

        public BullishSocketSpotMessageHandler()
        {
            AddTopicMapping<BullishSubscriptionEvent<BullishTradeSocketData>>(c => c.Data.Symbol);
            AddTopicMapping<BullishSubscriptionEvent<BullishOrderBook>>(c => c.Data.Symbol);
            AddTopicMapping<BullishSubscriptionEvent<BullishTicker>>(c => c.Data.Symbol);
        }

        protected override MessageTypeDefinition[] TypeEvaluators { get; } = [
            new MessageTypeDefinition {
                Fields = [new PropertyFieldReference("error")],
                StaticIdentifier = "error"
            },
            new MessageTypeDefinition {                
                Fields = [new PropertyFieldReference("id")],
                TypeIdentifierCallback = x => x.FieldValue("id")!,
            },
            new MessageTypeDefinition {
                Fields = [new PropertyFieldReference("dataType")],
                TypeIdentifierCallback = x => x.FieldValue("dataType")!,
            },
        ];
    }
}
