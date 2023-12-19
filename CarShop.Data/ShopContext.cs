using CarShop.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
