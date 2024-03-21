using PropertyShop.Models;

namespace PropertyShop.Repositories
{
    public interface IPropertiesRepository
    {
        Task<IEnumerable<Property>> GetAllProperties();
        Task<Property> GetSingleProperty(int id);
        Task CreateProperty(Property property);
        Task UpdateProperty(Property property);
        Task DeleteProperty(int id);
    }
}

