using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Login { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        [Required]
        public string PasswordSalt { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual List<Wallet> Wallets { get; set; } = new List<Wallet>();
    }
}
