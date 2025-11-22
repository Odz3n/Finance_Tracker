using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class WalletDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
