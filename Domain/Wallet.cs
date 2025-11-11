using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public User User { get; set; } = null!;
        public Currency Currency { get; set; } = null!;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
