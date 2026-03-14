using Auth.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Auth.Infrastructure.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase(configuration["DatabaseName"] ?? "AuthDb");
        }

        public IMongoCollection<UserAccount> Users => _database.GetCollection<UserAccount>("Users");
    }
}
