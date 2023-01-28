using FizzBuzz.Api.Calculators;
using FizzBuzz.Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;

namespace FizzBuzz.Api.Endpoints
{
    public class FizzBuzzEndpoint
    {
        private readonly ICalculator fizzBuzzCalculator;
        private readonly IMemoryCache memoryCache;
        private readonly IFizzBuzzRepository fizzBuzzRepository;

        public FizzBuzzEndpoint(ICalculator fizzBuzzCalculator, IMemoryCache memoryCache)
        {
            this.fizzBuzzCalculator = fizzBuzzCalculator;
            this.memoryCache = memoryCache;
        }

        internal async Task<Ok<string>> GetFizzBuzz(int input)
        {
            if (memoryCache.TryGetValue(input, out string cacheResult))
            {
                return TypedResults.Ok(cacheResult);
            }

            var model = await fizzBuzzRepository.GetFizzBuzzModelById(input);

            if(model is not null)
            {
                memoryCache.Set(input, model.Result);

                return TypedResults.Ok(model.Result);
            }

            var result = await fizzBuzzCalculator.Calculate(input);

            memoryCache.Set(input, result);

            return TypedResults.Ok(result);
        }
    }
}
