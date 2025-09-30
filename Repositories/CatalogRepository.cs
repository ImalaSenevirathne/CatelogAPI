using CatalogAPI.Data;
using CatalogAPI.Entities;
using MongoDB.Driver;

namespace CatalogAPI.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly IMongoCollection<Item> _items;

        public CatalogRepository(CatalogContext context)
        {
            _items = context.Items;
        }

        public async Task CreateAsync(Item item)
        {
            await _items.InsertOneAsync(item);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _items.DeleteOneAsync(i => i.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _items.Find(_ => true).ToListAsync();
        }

        public async Task<Item> GetByIdAsync(string id)
        {
            return await _items.Find(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(string id, Item item)
        {
            var result = await _items.ReplaceOneAsync(i => i.Id == id, item);
            return result.ModifiedCount > 0;
        }
    }
}
