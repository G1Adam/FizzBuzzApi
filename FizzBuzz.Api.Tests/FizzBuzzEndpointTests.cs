using FizzBuzz.Api.Calculators;
using FizzBuzz.Api.Endpoints;
using FizzBuzz.Api.Models;
using FizzBuzz.Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace FizzBuzz.Api.Tests
{
    public class FizzBuzzEndpointTests
    {
        private readonly Mock<ICalculator> mockCalculator;
        private readonly Mock<IFizzBuzzRepository> mockFizzBuzzRepository;
        private readonly MemoryCache cache;

        public FizzBuzzEndpointTests()
        {
            mockCalculator= new Mock<ICalculator>();
            mockFizzBuzzRepository= new Mock<IFizzBuzzRepository>();

            var options = Microsoft.Extensions.Options.Options.Create(new MemoryCacheOptions());

            cache = new MemoryCache(options);
        }

        [Fact]
        public async Task GetFizzBuzz_When_InputMatchesCacheKey_Should_ReturnFizzBuzzResult()
        {
            //Arrange
            int input = 5;
            string result = "buzz";

            cache.Set(input, result);

            //Act
            var fizzBuzzResult = await FizzBuzzEndpoint.GetFizzBuzz(input, mockCalculator.Object, cache, mockFizzBuzzRepository.Object);

            //Assert
            Assert.IsType<Ok<string>>(fizzBuzzResult);

            Assert.Equal(200, fizzBuzzResult.StatusCode);
            Assert.Equal("buzz", fizzBuzzResult.Value);
        }

        [Fact]
        public async Task GetFizzBuzz_When_CacheMissesButResultIsInDatabase_Should_ReturnFizzBuzzResult()
        {
            //Arrange
            int input = 5;
            string result = "buzz";

            FizzBuzzModel model = new FizzBuzzModel { Input= input, Result = result };

            mockFizzBuzzRepository.Setup(x => x.GetFizzBuzzModelById(It.Is<int>(i => i == input))).ReturnsAsync(model);

            //Act
            var fizzBuzzResult = await FizzBuzzEndpoint.GetFizzBuzz(input, mockCalculator.Object, cache, mockFizzBuzzRepository.Object);

            //Assert
            Assert.IsType<Ok<string>>(fizzBuzzResult);

            Assert.Equal(200, fizzBuzzResult.StatusCode);
            Assert.Equal("buzz", fizzBuzzResult.Value);
        }

        [Fact]
        public async Task GetFizzBuzz_When_FizzBuzzResultIsNotInCacheOrDatabase_Should_ReturnFizzBuzzResult()
        {
            //Arrange
            int input = 5;
            string result = "buzz";
            FizzBuzzModel model = null;

            mockFizzBuzzRepository.Setup(x => x.GetFizzBuzzModelById(It.Is<int>(i => i == input))).ReturnsAsync(model);

            mockCalculator.Setup(x => x.Calculate(It.Is<int>(i => i == input))).ReturnsAsync(result);

            //Act
            var fizzBuzzResult = await FizzBuzzEndpoint.GetFizzBuzz(input, mockCalculator.Object, cache, mockFizzBuzzRepository.Object);

            //Assert
            Assert.IsType<Ok<string>>(fizzBuzzResult);

            Assert.Equal(200, fizzBuzzResult.StatusCode);
            Assert.Equal("buzz", fizzBuzzResult.Value);
        }
    }
}
