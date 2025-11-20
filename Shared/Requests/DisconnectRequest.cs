using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class DisconnectRequest : Request
    {
        public override RequestType? Type => RequestType.Disconnect;
    }
}
