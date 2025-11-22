using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TransactionTypeId { get; set; }
        public override string ToString()
        {
            return $"{Name} - {TransactionTypeId}";
        }

    }
}
