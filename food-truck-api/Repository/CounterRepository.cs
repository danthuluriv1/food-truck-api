using food_truck_api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace food_truck_api.Repository
{
    public class CounterRepository
    {
        private readonly IMongoCollection<Counter> _counterCollection;
        private readonly IOptions<AppSettings> _appSettings;

        public CounterRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            var mongoClient = new MongoClient(_appSettings?.Value.ConnectionStrings?.AppDbConnectionString);
            var appdbDatabase = mongoClient.GetDatabase(_appSettings?.Value.ConnectionStrings?.AppDbDatabaseName);
            _counterCollection = appdbDatabase.GetCollection<Counter>("counter");
        }

        public async Task<List<Counter>> GetAllAsync()
        {
            return await _counterCollection.Find(_ => true).ToListAsync();
        }
        public async Task UpdateAsync(Counter counter)
        {
            await _counterCollection.ReplaceOneAsync(_ => _.Id == counter.Id, counter);
        }
    }
}
