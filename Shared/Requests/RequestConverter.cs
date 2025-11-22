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
                    case (int)RequestType.GetWallets:
                        return jsonDoc.Deserialize<GetWalletsRequest>(options);
                    case (int)RequestType.AddWallet:
                        return jsonDoc.Deserialize<AddWalletRequest>(options);
                    case (int)RequestType.GetCurrencies:
                        return jsonDoc.Deserialize<GetCurrenciesRequest>(options);
                    case (int)RequestType.DeleteWallet:
                        return jsonDoc.Deserialize<DeleteWalletRequest>(options);
                    case (int)RequestType.GetCategories:
                        return jsonDoc.Deserialize<GetCategoriesRequest>(options);
                    case (int)RequestType.GetTransactionTypes:
                        return jsonDoc.Deserialize<GetTransactionTypesRequest>(options);
                    case (int)RequestType.AddCategory:
                        return jsonDoc.Deserialize<AddCategoryRequest>(options);
                    case (int)RequestType.DeleteCategory:
                        return jsonDoc.Deserialize<DeleteCategoryRequest>(options);
                    case (int)RequestType.GetTransactions:
                        return jsonDoc.Deserialize<GetTransactionsRequest>(options);
                    case (int)RequestType.AddTransaction:
                        return jsonDoc.Deserialize<AddTransactionRequest>(options);
                    case (int)RequestType.DeleteTransaction:
                        return jsonDoc.Deserialize<DeleteTransactionRequest>(options);
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
