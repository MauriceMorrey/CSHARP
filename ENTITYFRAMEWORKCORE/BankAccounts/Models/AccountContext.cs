using Microsoft.EntityFrameworkCore;
 
namespace BankAccounts.Models
{
    public class AccountContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Login> Login { get; set; }
        
        
        
    }
}
