using Microsoft.EntityFrameworkCore;
using PropertyShop.Models;

namespace PropertyShop.Data
{
    public class PropertyShopDbContext: DbContext
    {
        public PropertyShopDbContext(DbContextOptions<PropertyShopDbContext> options) : base(options) { }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Agent> Agents { get; set; }
    }
}
