using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class AddWalletResponse : Response
    {
        public override ResponseType? Type => ResponseType.AddWallet;
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
