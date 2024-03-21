using Microsoft.EntityFrameworkCore;
using PropertyShop.Data;
using PropertyShop.Models;

namespace PropertyShop.Repositories
{
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly PropertyShopDbContext _dbContext;

        public PropertiesRepository(PropertyShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Property>> GetAllProperties()
        {
            var properties = await _dbContext.Properties.ToListAsync();
            return properties;
        }
        public async Task<Property> GetSingleProperty(int id)
        {
            return await _dbContext.Properties.FirstOrDefaultAsync(p => p.id == id);
        }
        public async Task CreateProperty(Property property)
        {
            await _dbContext.Properties.AddAsync(property);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteProperty(int id)
        {
            var property = await _dbContext.Properties.FirstOrDefaultAsync(p => p.id == id);
            if (property != null)
            {
                _dbContext.Properties.Remove(property);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateProperty(Property property)
        {
            _dbContext.Entry(property).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
