using CatalogAPI.Entities;

namespace CatalogAPI.Repositories
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(string id);
        Task CreateAsync(Item item);
        Task<bool> UpdateAsync(string id, Item item);
        Task<bool> DeleteAsync(string id);
    }
}
