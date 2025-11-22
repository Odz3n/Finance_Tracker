using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class WalletsReceivedEventArgs
    {
        public List<WalletDTO>? Wallets { get; set; } 
    }
}
