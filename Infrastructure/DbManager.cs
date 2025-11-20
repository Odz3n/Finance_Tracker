using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DbManager: IDisposable
    {
        readonly FinanceTrackerDbContext? _context;
        public DbManager(FinanceTrackerDbContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(string login, string firstName, string lastName, string passHash, string passSalt)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddUserAsync: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
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
    }
}
