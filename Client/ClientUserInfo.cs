using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientUserInfo
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public DateTime? ConnectionTime { get; set; }
    }
}
