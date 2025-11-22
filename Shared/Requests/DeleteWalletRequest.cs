using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class DeleteWalletRequest : Request
    {
        public override RequestType? Type => RequestType.DeleteWallet;
        public int UserId { get; set; }
        public string? WalletName { get; set; }
    }
}
