using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int? WalletId { get; set; }
        public int CurrencyId { get; set; }
        public int? TransactionCategoryId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }
        public Wallet Wallet { get; set; } = null!;
        public Currency Currency { get; set; } = null!;
        public TransactionCategory TransactionCategory { get; set; } = null!;
    }
}
