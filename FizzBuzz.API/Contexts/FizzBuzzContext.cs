using FizzBuzz.Api.Models;
using FizzBuzz.Api.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FizzBuzz.Api.Contexts
{
    public class FizzBuzzContext : IFizzBuzzContext
    {
        public FizzBuzzContext(IOptions<FizzBuzzDatabaseOptions> fizzBuzzDatabaseOptions)
        {
            var client = new MongoClient(fizzBuzzDatabaseOptions.Value.ConnectionString);

            var database = client.GetDatabase(fizzBuzzDatabaseOptions.Value.DatabaseName);

            FizzBuzzCollection = database.GetCollection<FizzBuzzModel>(fizzBuzzDatabaseOptions.Value.CollectionName);
        }

        public IMongoCollection<FizzBuzzModel> FizzBuzzCollection { get; }
    }
}
