using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Events
{
    public class DisconnectMessageReceivedEventArgs: EventArgs
    {
        public string? Message { get; set; }
    }
}
