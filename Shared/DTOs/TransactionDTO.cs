using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? WalletId { get; set; }
        public int? CurrencyId { get; set; }
        public int? TransactionCategoryId { get; set; }
        public decimal Value { get; set; }
        public string? Note { get; set; }
        public override string ToString()
        {
            return $"ID[{Id}] D[{Date.ToShortDateString()}] TC[{TransactionCategoryId}] A[{Value}]";
        }
    }
}
