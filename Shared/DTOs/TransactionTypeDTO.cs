using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class TransactionTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
