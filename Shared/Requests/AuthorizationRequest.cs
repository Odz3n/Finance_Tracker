using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class AuthorizationRequest : Request
    {
        public override RequestType? Type => RequestType.Auth;
        public string? Login { get; set; }
        public string? Password { get; set; }
        public TcpClient? Client { get; set; }
    }
}
