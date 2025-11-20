using Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class RegistrationResponse : Response
    {
        public override ResponseType? Type => ResponseType.Reg;
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
