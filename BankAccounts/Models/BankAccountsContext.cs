using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

 
namespace BankAccounts.Models
{
    public class BankAccountsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankAccountsContext(DbContextOptions<BankAccountsContext> options) : base(options) { }
        // public BankAccountsContext(DbContextOptions options) : base (options) 
        // { }
        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
    }
}
