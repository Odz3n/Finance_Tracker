using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FinanceTrackerDbContextFactory : IDesignTimeDbContextFactory<FinanceTrackerDbContext>
    {
        public FinanceTrackerDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appconfig.json")
                .Build();

            var options = new DbContextOptionsBuilder<FinanceTrackerDbContext>()
                .UseLazyLoadingProxies()
                .UseSqlServer(builder.GetConnectionString("SqlClient"))
                .Options;

            return new FinanceTrackerDbContext(options);
        }
    }
}
