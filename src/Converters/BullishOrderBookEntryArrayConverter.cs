using System.Text.Json;
using System.Text.Json.Serialization;
using Bullish.Net.Objects.Models;

namespace Bullish.Net.Converters
{
    internal class BullishOrderBookEntryArrayConverter : JsonConverter<IEnumerable<BullishOrderBookEntry>>
    {
        public override IEnumerable<BullishOrderBookEntry> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException("Expected an array.");
            }

            var bookEntries = new System.Collections.Generic.List<BullishOrderBookEntry>();

            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException("Expected a string value for the price.");
                }
                var price = decimal.Parse(reader.GetString() ?? "0");

                if (!reader.Read() || reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException("Expected a string value for the quantity.");
                }
                var quantity = decimal.Parse(reader.GetString() ?? "0");

                bookEntries.Add(new BullishOrderBookEntry { Price = price, Quantity = quantity });
            }

            return bookEntries;
        }

        public override void Write(Utf8JsonWriter writer, IEnumerable<BullishOrderBookEntry> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var entry in value)
            {
                writer.WriteStringValue(entry.Price.ToString());
                writer.WriteStringValue(entry.Quantity.ToString());
            }
            writer.WriteEndArray();
        }
    }
}
