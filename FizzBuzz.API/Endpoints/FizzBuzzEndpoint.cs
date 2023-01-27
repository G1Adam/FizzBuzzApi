using FizzBuzz.Api.Calculators;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;

namespace FizzBuzz.Api.Endpoints
{
    public class FizzBuzzEndpoint
    {
        private readonly ICalculator fizzBuzzCalculator;
        private readonly IMemoryCache memoryCache;

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

            //Check Database

            var result = await fizzBuzzCalculator.Calculate(input);

            memoryCache.Set(input, result);

            return TypedResults.Ok(result);
        }
    }
}
