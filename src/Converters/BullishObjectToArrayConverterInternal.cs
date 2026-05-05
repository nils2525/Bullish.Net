using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bullish.Net.Converters
{
    internal class BullishObjectToArrayConverterInternal<T> : JsonConverter<T>
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (!typeToConvert.IsArray)
                return JsonDocument.ParseValue(ref reader).Deserialize<T>(options);

            if (reader.TokenType == JsonTokenType.StartArray)
                return JsonDocument.ParseValue(ref reader).Deserialize<T>(options);

            var elementType = typeToConvert.GetElementType()!;
            var element = JsonDocument.ParseValue(ref reader).Deserialize(elementType, options);
            var array = Array.CreateInstance(elementType, 1);
            array.SetValue(element, 0);
            return (T)(object)array;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, value, options);
    }
}