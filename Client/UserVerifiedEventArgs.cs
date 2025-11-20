using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class UserVerifiedEventArgs: EventArgs
    {
        public bool? IsVerified { get; set; }
    }
}
