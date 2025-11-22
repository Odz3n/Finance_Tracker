using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class GetWalletsResponse : Response
    {
        public override ResponseType? Type => ResponseType.GetWallets;
        public List<WalletDTO>? Wallets { get; set; }
    }
}
