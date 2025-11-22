using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class GetWalletsRequest : Request
    {
        public override RequestType? Type => RequestType.GetWallets;
        public int UserId { get; set; }
    }
}
