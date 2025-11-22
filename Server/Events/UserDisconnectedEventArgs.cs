using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Events
{
    public class UserDisconnectedEventArgs: EventArgs
    {
        public ConnectedUser? User { get; set; }
    }
}
