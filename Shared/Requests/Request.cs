using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public enum RequestType
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
    [JsonConverter(typeof(RequestConverter))]
    public abstract class Request
    {
        public string? Id { get; } = Guid.NewGuid().ToString();
        public abstract RequestType? Type { get; }
        public DateTime? SentAt { get; } = DateTime.Now;
    }
}
