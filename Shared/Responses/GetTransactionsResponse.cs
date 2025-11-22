using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace Shared.Responses
{
    public class GetTransactionsResponse : Response
    {
        public override ResponseType? Type => ResponseType.GetTransactions;
        public List<TransactionDTO>? Transactions { get; set; }
    }
}
