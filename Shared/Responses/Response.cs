using Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public enum ResponseType
    {
        Reg,
        Auth,
        Disconnect,
        GetWallets,
        GetCategories,
        GetTransactions,
        GetTransactionTypes,
        GetCurrencies,
        AddWallet,
        AddCategory,
        AddTransaction,
        DeleteWallet,
        DeleteCategory,
        DeleteTransaction,
        UpdateWallet,
        UpdateCategory,
        UpdateTransaction
    }
    [JsonConverter(typeof(ResponseConverter))]
    public abstract class Response
    {
        public string? Id { get; } = Guid.NewGuid().ToString();
        public abstract ResponseType? Type { get; }
        public DateTime? SentAt { get; } = DateTime.Now;
    }
}
