using Microsoft.EntityFrameworkCore;
using JewelryStore.Model;

namespace JewelryStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
            //Database.Migrate();
        }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<TheProduct> TheProducts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
