using FizzBuzz.Api.Calculators;
using FizzBuzz.Api.Contexts;
using FizzBuzz.Api.Endpoints;
using FizzBuzz.Api.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics.CodeAnalysis;

namespace FizzBuzz.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterFizzBuzzServices(this IServiceCollection services)
        {
            services.AddScoped<IFizzBuzzContext, FizzBuzzContext>();
            services.AddScoped<IFizzBuzzRepository, FizzBuzzRepository>();
            services.AddSingleton<ICalculator, FizzBuzzCalculator>();
            services.AddSingleton<IMemoryCache, MemoryCache>();

            return services;
        }
    }
}
