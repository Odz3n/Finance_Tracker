using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ConnectedUser
    {
        public int? Id { get; set; }
        public string? Login { get; set; }
        public TcpClient? Client { get; set; }
        public DateTime? ConnectionTime { get; set; }
        public DateTime? DisconnectionTime { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Login}";
        }
    }
}
