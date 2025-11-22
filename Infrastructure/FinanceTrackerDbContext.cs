using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class FinanceTrackerDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User <=> Wallets
            modelBuilder.Entity<User>(u =>
            {
                u.HasMany(u => u.Wallets)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                u.HasIndex(u => u.Login)
                .IsUnique();
            });

            // User <=> TransactionCategories
            //modelBuilder.Entity<User>(u =>
            //{
            //    u.HasMany(u => u.TransactionCategories)
            //    .WithOne(tc => tc.User)
            //    .HasForeignKey(tc => tc.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //});

            // Wallet <=> Transactions
            modelBuilder.Entity<Wallet>(w =>
            {
                w.HasMany(w => w.Transactions)
                .WithOne(t => t.Wallet)
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.SetNull);
            });

            // TransCat <=> Transactions
            modelBuilder.Entity<TransactionCategory>(tc =>
            {
                tc.HasMany(tc => tc.Transactions)
                .WithOne(t => t.TransactionCategory)
                .HasForeignKey(t => t.TransactionCategoryId)
                .OnDelete(DeleteBehavior.SetNull);
            });

            // TransType <=> TransCat
            modelBuilder.Entity<TransactionType>(tt =>
            {
                tt.HasMany(tt => tt.TransactionCategories)
                .WithOne(tc => tc.TransactionType)
                .HasForeignKey(tc => tc.TransactionTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
