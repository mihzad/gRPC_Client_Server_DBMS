using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Client.ClassHierarchy;

namespace Client
{
    public class SupportedTypeConverter : JsonConverter<SupportedType>
    {
        public override SupportedType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            reader.Read();
            string TypePropertyName = reader.GetString()!;

            reader.Read();
            string TypePropertyValue = reader.GetString()!;

            reader.Read();
            string InputPropertyName = reader.GetString()!;

            reader.Read();
            string InputPropertyValue = reader.GetString()!;

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndObject)
                throw new JsonException();

            var v = SupportMethods.createSupportedTypeInstance(TypePropertyValue, InputPropertyValue);
            if (v == null) throw new Exception();
            return v;
        }

        public override void Write(Utf8JsonWriter writer, SupportedType value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("Type");
            writer.WriteStringValue(value.Type);

            writer.WritePropertyName("Input");
            writer.WriteStringValue(value.stringOutput());

            writer.WriteEndObject();
        }
    }
}
