using BankingAppWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingAppWebApi.Data
{
    public class BankingContext
          : DbContext
    {
        public BankingContext(DbContextOptions options)
            : base(options)
        {



        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankAccountType> BankAccountTypes { get; set; }
        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


    }
}
