using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Events
{
    public class TransactionsReceivedEventArgs: EventArgs
    {
        public List<TransactionDTO>? Transactions { get; set; }
    }
}
