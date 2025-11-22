using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class AddWalletRequest : Request
    {
        public override RequestType? Type => RequestType.AddWallet;
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
    }
}
