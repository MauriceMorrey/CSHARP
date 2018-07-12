using Microsoft.EntityFrameworkCore;
 
namespace WeddingPlanner.Models
{
    public class WeddingPContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingPContext(DbContextOptions<WeddingPContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Wedders> Wedders { get; set; }  
        public DbSet<Visitors> Visitors { get; set; }          
        public DbSet<Login> Login { get; set; }
              
        
        
        
    }
}