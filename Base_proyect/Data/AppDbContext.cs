using Microsoft.EntityFrameworkCore;
using Base_proyect.Models;

namespace Base_proyect.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }




        protected AppDbContext()
        {
        }
    }
}
