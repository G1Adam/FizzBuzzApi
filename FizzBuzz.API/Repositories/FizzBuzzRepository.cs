using FizzBuzz.Api.Contexts;
using FizzBuzz.Api.Models;
using MongoDB.Driver;

namespace FizzBuzz.Api.Repositories
{
    public class FizzBuzzRepository : IFizzBuzzRepository
    {
        private readonly IFizzBuzzContext fizzBuzzContext;

        public FizzBuzzRepository(IFizzBuzzContext fizzBuzzContext)
        {
            this.fizzBuzzContext = fizzBuzzContext;
        }

        public async Task InsertFizzBuzzModel(FizzBuzzModel model)
        {
            await fizzBuzzContext.FizzBuzzCollection.InsertOneAsync(model);
        }

        public async Task<FizzBuzzModel> GetFizzBuzzModelById(int input)
        {
            return await fizzBuzzContext.FizzBuzzCollection.Find(c => c.Input == input).FirstOrDefaultAsync();
        }
    }
}
