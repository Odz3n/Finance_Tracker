using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Events
{
    public class UserVerifiedEventArgs: EventArgs
    {
        public bool? IsVerified { get; set; }
        public int UserId { get; set; }
        public string? UserLogin { get; set; }
        public DateTime? UserConnectionTime { get; set; }
    }
}
