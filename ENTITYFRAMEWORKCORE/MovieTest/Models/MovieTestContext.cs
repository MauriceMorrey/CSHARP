using Microsoft.EntityFrameworkCore;

namespace MovieTest.Models
{
    public class MovieTestContext : DbContext
    {
        public MovieTestContext (DbContextOptions<MovieTestContext> options)
            : base(options)
        {
        }

        public DbSet<MovieTest.Models.Movie> Movie { get; set; }
    }
}