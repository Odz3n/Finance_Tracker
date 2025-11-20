using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class RequestConverter : JsonConverter<Request>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Request).IsAssignableFrom(typeToConvert);
        }
        public override Request? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                switch (jsonDoc.RootElement.GetProperty("Type").GetInt32())
                {
                    case (int)RequestType.Reg:
                        return jsonDoc.Deserialize<RegistrationRequest>(options);
                    case (int)RequestType.Auth:
                        return jsonDoc.Deserialize<AuthorizationRequest>(options);
                    case (int)RequestType.Disconnect:
                        return jsonDoc.Deserialize<DisconnectRequest>(options);
                    default:
                        throw new JsonException("'Type' doesn't match a known derived type");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, Request value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}
