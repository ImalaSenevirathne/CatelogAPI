using CatalogAPI.Entities;
using MongoDB.Driver;

namespace CatalogAPI.Data
{
    public class CatalogContext
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;

        public CatalogContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(configuration.GetSection("MongoDbSettings:ConnectionString").Value);
            _database = client.GetDatabase(configuration.GetSection("MongoDbSettings:DatabaseName").Value);
        }

        public IMongoCollection<Item> Items => _database.GetCollection<Item>(_configuration.GetSection("MongoDbSettings:CollectionName").Value);
    }
}
