using Microsoft.EntityFrameworkCore;
 
namespace RESTauranter.Models
{
    public class ReviewsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ReviewsContext(DbContextOptions<ReviewsContext> options) : base(options) { }
        public DbSet<RegisterViewModels> Reviews { get; set; }
    }
}
