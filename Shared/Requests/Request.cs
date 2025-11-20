using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public enum RequestType
    {
        Reg,
        Auth,
        Get,
        Add,
        Delete,
        Update
    }
    [JsonConverter(typeof(RequestConverter))]
    public abstract class Request
    {
        public string? Id { get; } = Guid.NewGuid().ToString();
        public abstract RequestType? Type { get; }
        public TcpClient? Sender { get; set; }
        public DateTime? SentAt { get; } = DateTime.Now;
    }
}
