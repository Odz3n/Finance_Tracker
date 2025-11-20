using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class RegistrationRequest : Request
    {
        public override RequestType? Type => RequestType.Reg;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
