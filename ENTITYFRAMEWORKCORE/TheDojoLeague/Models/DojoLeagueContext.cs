using Microsoft.EntityFrameworkCore;
 
namespace TheDojoLeague.Models
{
    public class DojoLeagueContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DojoLeagueContext(DbContextOptions<DojoLeagueContext> options) : base(options) { }
        public DbSet<Ninjas> Ninjas { get; set; }
        public DbSet<Dojos> Dojos { get; set; }  
    }
}