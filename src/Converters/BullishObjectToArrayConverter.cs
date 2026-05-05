using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bullish.Net.Converters
{
    internal class BullishObjectToArrayConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
            => true;

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var type = typeof(BullishObjectToArrayConverterInternal<>).MakeGenericType(typeToConvert);
            return (JsonConverter)Activator.CreateInstance(type)!;
        }
    }
}