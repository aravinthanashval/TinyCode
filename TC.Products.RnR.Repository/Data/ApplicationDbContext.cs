using Microsoft.EntityFrameworkCore;
using TC.Products.RnR.Repository.Models;

namespace TC.Products.RnR.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        
        public DbSet<TC.Products.RnR.Repository.Models.Products> Products { get; set; }

        public DbSet<Reviews> Reviews { get; set; }

        public DbSet<ProductRating> ProductRating { get; set; }
    }
}
