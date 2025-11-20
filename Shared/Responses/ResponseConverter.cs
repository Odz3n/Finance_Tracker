using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class ResponseConverter : JsonConverter<Response>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Response).IsAssignableFrom(typeToConvert);
        }
        public override Response? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                switch (jsonDoc.RootElement.GetProperty("Type").GetInt32())
                {
                    case (int)ResponseType.Reg:
                        return jsonDoc.Deserialize<RegistrationResponse>(options);
                    case (int)ResponseType.Auth:
                        return jsonDoc.Deserialize<AuthorizationResponse>(options);
                    default:
                        throw new JsonException("'Type' doesn't match a known derived type");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, Response value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}
