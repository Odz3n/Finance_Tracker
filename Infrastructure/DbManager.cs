using Domain;
using Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace Infrastructure
{
    public class DbManager: IDisposable
    {
        readonly FinanceTrackerDbContext? _context;
        public DbManager(FinanceTrackerDbContext context)
        {
            _context = context;
        }
        public async Task<DbOperationResult> AddUserAsync(string login, string firstName, string lastName, string passHash, string passSalt)
        {
            try
            {
                if (_context.Users.FirstOrDefault(u => u.Login == login) != null)
                {
                    return new DbOperationResult { IsSuccess = false, Message = $"User '{login}' exists." };
                }

                User user = new User
                {
                    Login = login,
                    FirstName = firstName,
                    LastName = lastName,
                    PasswordHash = passHash,
                    PasswordSalt = passSalt
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return new DbOperationResult { IsSuccess = true, Message = $"'{login}' registered successfully." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddUserAsync: {ex.Message}");
                return new DbOperationResult { IsSuccess = false, Message = $"Exception occurd '{ex.Message}'" };
            }
        }
        public async Task<DbOperationResult> AddWalletAsync(string name, decimal balance, int userId, int currencyId)
        {
            try
            {
                var dupl = await _context.Wallets
                    .Where(w => w.UserId == userId && w.Name == name)
                    .FirstOrDefaultAsync();

                if (dupl != null)
                    return new DbOperationResult { IsSuccess = false, Message = "The user already has such a wallet." };

                var wallet = new Wallet
                {
                    Name = name,
                    Balance = balance,
                    UserId = userId,
                    CurrencyId = currencyId
                };

                await _context.Wallets.AddAsync(wallet);
                await _context.SaveChangesAsync();

                return new DbOperationResult { IsSuccess = true, Message = "Wallet successfully added." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddWalletAsync: {ex.Message}");
                return new DbOperationResult { IsSuccess = false, Message = "Exception occured." };
            }
        }
        public async Task<DbOperationResult> AddCategoryAsync(string name, int transactionTypeId)
        {
            try
            {
                if (_context.TransactionCategories.FirstOrDefault(tc => tc.Name == name && tc.TransactionTypeId == transactionTypeId) != null)
                {
                    return new DbOperationResult { IsSuccess = false, Message = $"Category '{name}' exists." };
                }

                TransactionCategory category = new TransactionCategory
                {
                    Name = name,
                    TransactionTypeId = transactionTypeId
                };

                await _context.TransactionCategories.AddAsync(category);
                await _context.SaveChangesAsync();
                return new DbOperationResult { IsSuccess = true, Message = $"Category '{name}' added." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddCategoryAsync: {ex.Message}");
                return new DbOperationResult { IsSuccess = false, Message = $"Exception occurd '{ex.Message}'" };
            }
        }
        public async Task<DbOperationResult> AddTransactionAsync(int walletId, int currencyId, int categoryId, decimal amount, DateTime date, string? note)
        {
            try
            {
                var transaction = new Transaction
                {
                    WalletId = walletId,
                    CurrencyId = currencyId,
                    TransactionCategoryId = categoryId,
                    Value = amount,
                    Date = date,
                    Note = note ?? ""
                };

                var wallet = await _context.Wallets
                    .Include(w => w.Transactions)
                    .FirstOrDefaultAsync(w => w.Id == walletId);

                if (wallet == null)
                    return new DbOperationResult { IsSuccess = false, Message = "Wallet not found." };

                var category = await _context.TransactionCategories
                    .Include(c => c.TransactionType)
                    .FirstOrDefaultAsync(c => c.Id == categoryId);

                if (category?.TransactionType == null)
                {
                    return new DbOperationResult { IsSuccess = false, Message = "Transaction category or type not found." };
                }

                Console.WriteLine($"Transaction Type: {category.TransactionType.Name}");

                if (category.TransactionType.Name == "Income")
                    wallet.Balance += amount;
                else if (category.TransactionType.Name == "Expense")
                    wallet.Balance -= amount;
                else
                {
                    return new DbOperationResult { IsSuccess = false, Message = "Invalid transaction type." };
                }

                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();

                return new DbOperationResult { IsSuccess = true, Message = "Transaction added." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddTransactionAsync: {ex.Message}");
                return new DbOperationResult { IsSuccess = false, Message = "Exception occurred." };
            }
        }
        public async Task<DbOperationResult> DeleteWalletAsync(int userId, string walletName)
        {
            try
            {
                var wallet = await _context.Wallets
                    .Where(w => w.UserId == userId && w.Name == walletName)
                    .FirstOrDefaultAsync();

                if (wallet == null)
                    return new DbOperationResult { IsSuccess = false, Message = $"Wallet '{walletName}' doesn't exist." };

                _context.Wallets.Remove(wallet);
                await _context.SaveChangesAsync();

                return new DbOperationResult { IsSuccess = true, Message = $"Wallet '{walletName}' successfully deleted." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeletWalletAsync: {ex.Message}");
                return new DbOperationResult { IsSuccess = false, Message = "Exception occured." };
            }
        }
        public async Task<DbOperationResult> DeleteCategoryAsync(string name, int transactionTypeId)
        {
            try
            {
                var category = await _context.TransactionCategories
                    .FirstOrDefaultAsync(tc => tc.Name == name && tc.TransactionTypeId == transactionTypeId);

                if (category == null)
                    return new DbOperationResult { IsSuccess = false, Message = $"Category '{name}' doesn't exist." };

                _context.TransactionCategories.Remove(category);
                await _context.SaveChangesAsync();

                return new DbOperationResult { IsSuccess = true, Message = $"Category '{name}' deleted." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteCategoryAsync: {ex.Message}");
                return new DbOperationResult { IsSuccess = false, Message = $"Exception occured: {ex.Message}" };
            }
        }
        public async Task<DbOperationResult> DeleteTransactionAsync(int transactionId)
        {
            try
            {
                var transaction = await _context.Transactions
                    .Where(t => t.Id == transactionId)
                    .FirstOrDefaultAsync();
                if (transaction == null)
                    return new DbOperationResult { IsSuccess = false, Message = "No such transaction in Data Base." };

                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
                return new DbOperationResult { IsSuccess = true, Message = "Transaction deleted." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteTransactionAsync: {ex.Message}");
                return new DbOperationResult { IsSuccess = false, Message = $"Exception occured {ex.Message}." };
            }
        }
        public async Task<User?> GetUserByLoginAsync(string login)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetUserByLoginAsync: {ex.Message}");
                return null;
            }
        }
        public async Task<User?> VerifyUser(string login, string pass)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);

                if (user == null)
                    return null;

                if (PasswordHelper.VerifyPassword(pass, user.PasswordHash, user.PasswordSalt) == true)
                    return user;

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"VerifyUserExistence: {ex.Message}");
                return null;
            }
        }
        public async Task<List<WalletDTO>?> GetWalletsAsync(int userId)
        {
            try
            {
                var res = await _context.Wallets
                    .Include(w => w.User)
                    .Where(w => w.UserId == userId)
                    .Select(w => new WalletDTO
                    {
                        Id = w.Id,
                        Name = w.Name,
                        Balance = w.Balance,
                        UserId =  w.UserId,
                        CurrencyId = w.CurrencyId
                    }).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetWalletsAsync: {ex.Message}");
                return new List<WalletDTO>();
            }
        }
        public async Task<List<CurrencyDTO>?> GetCurrenciesAsync()
        {
            try
            {
                var res = await _context.Currencies
                    .Select(c => new CurrencyDTO
                    {
                        Id = c.Id,
                        Code = c.Code,
                        Name = c.Name,
                        Symbol = c.Symbol,
                        Rate = c.Rate
                    }).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCurrenciesAsync: {ex.Message}");
                return new List<CurrencyDTO>();
            }
        }
        public async Task<List<CategoryDTO>?> GetCategoriesAsync()
        {
            try
            {
                var res = await _context.TransactionCategories
                    .Select(tc => new CategoryDTO
                    {
                        Id = tc.Id,
                        Name = tc.Name,
                        TransactionTypeId = tc.TransactionTypeId
                    }).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCategoriesAsync: {ex.Message}");
                return new List<CategoryDTO>();
            }
        }
        public async Task<List<TransactionDTO>?> GetTransactionsAsync(int userId)
        {
            try
            {
                var res = await _context.Transactions
                    .Where(t => t.Wallet != null && t.Wallet.UserId == userId)
                    .Select(t => new TransactionDTO
                    {
                        Id = t.Id,
                        Date = t.Date,
                        WalletId = t.WalletId,
                        CurrencyId = t.CurrencyId,
                        TransactionCategoryId = t.TransactionCategoryId,
                        Value = t.Value,
                        Note = t.Note
                    }).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetTransactionsAsync: {ex.Message}");
                return new List<TransactionDTO>();
            }
        }
        public async Task<List<TransactionTypeDTO>?> GetTransactionTypesAsync()
        {
            try
            {
                var res = await _context.TransactionTypes
                    .Select(tt => new TransactionTypeDTO
                    {
                        Id = tt.Id,
                        Name = tt.Name,
                    }).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCategoriesAsync: {ex.Message}");
                return new List<TransactionTypeDTO>();
            }
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
