using Microsoft.EntityFrameworkCore;
using RockyTwo.Models;

namespace RockyTwo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
               
        }

        public DbSet<Category>  Category { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
