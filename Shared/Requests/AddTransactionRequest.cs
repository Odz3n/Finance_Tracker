using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class AddTransactionRequest : Request
    {
        public override RequestType? Type => RequestType.AddTransaction;
        public int WalletId { get; set; }
        public int CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string? Note { get; set; }
    }
}
