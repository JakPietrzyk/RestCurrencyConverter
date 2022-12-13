using curRESTAPI.Dtos;
using MongoDB.Driver;

namespace curRESTAPI.Repositories
{
    public class MongoRepository : IAllCurrency
    {
        private const string databaseName = "currencyNames";
        private const string collectionName = "currency";
        private readonly IMongoCollection<CurrencyNames> currencyCollection;
        public MongoRepository(IMongoClient mongoClient) 
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            currencyCollection = database.GetCollection<CurrencyNames>(collectionName);
        }


        public Task<IEnumerable<CurrencyNames>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Root> GetLastAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Root> GetLastCurrencyUserDefined(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Root>> GetTenLastAsync()
        {
            throw new NotImplementedException();
        }
    }
}
