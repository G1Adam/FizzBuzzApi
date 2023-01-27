using FizzBuzz.Api.Models;
using MongoDB.Driver;

namespace FizzBuzz.Api.Contexts
{
    public interface IFizzBuzzContext
    {
        IMongoCollection<FizzBuzzModel> FizzBuzzCollection { get; }
    }
}
