using Microsoft.EntityFrameworkCore;
 
namespace RestReview.Models
{
    public class RestaurantContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
        public DbSet<Review> reviews { get; set; }
    }
}
