using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TransactionCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public int TransactionTypeId { get; set; }
        public virtual TransactionType TransactionType { get; set; } = null!;
        public virtual List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
