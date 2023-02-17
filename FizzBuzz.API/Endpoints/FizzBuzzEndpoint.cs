using FizzBuzz.Api.Calculators;
using FizzBuzz.Api.Models;
using FizzBuzz.Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;

namespace FizzBuzz.Api.Endpoints
{
    public static class FizzBuzzEndpoint
    {
        public static WebApplication MapFizzBuzzEndpoint(this WebApplication webApplication)
        {
            webApplication.MapGet("/", GetFizzBuzz).WithOpenApi();

            return webApplication;
        }

        internal static async Task<Ok<string>> GetFizzBuzz(int input, ICalculator fizzBuzzCalculator, IMemoryCache memoryCache, IFizzBuzzRepository fizzBuzzRepository)
        {
            if (memoryCache.TryGetValue(input, out string cacheResult))
            {
                return TypedResults.Ok(cacheResult);
            }

            var model = await fizzBuzzRepository.GetFizzBuzzModelById(input);

            if (model is not null)
            {
                memoryCache.Set(input, model.Result);

                return TypedResults.Ok(model.Result);
            }

            var result = await fizzBuzzCalculator.Calculate(input);

            await fizzBuzzRepository.InsertFizzBuzzModel(new FizzBuzzModel { Input = input, Result = result });

            memoryCache.Set(input, result);

            return TypedResults.Ok(result);
        }
    }
}
