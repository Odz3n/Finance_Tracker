using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class DisconnectUserResponse : Response
    {
        public override ResponseType? Type => ResponseType.Disconnect;
        public string? Message { get; set; }
    }
}
