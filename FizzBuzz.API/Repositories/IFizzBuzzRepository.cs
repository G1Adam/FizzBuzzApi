using FizzBuzz.Api.Models;

namespace FizzBuzz.Api.Repositories
{
    public interface IFizzBuzzRepository
    {
        Task<FizzBuzzModel> GetFizzBuzzModelById(int input);

        Task InsertFizzBuzzModel(FizzBuzzModel model);
    }
}
