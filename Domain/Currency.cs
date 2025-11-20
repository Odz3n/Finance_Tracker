using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Code { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(5)]
        public string? Symbol { get; set; }
        public decimal Rate { get; set; }
        public virtual List<Wallet> Wallets { get; set; } = new List<Wallet>();
    }
}
