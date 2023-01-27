namespace FizzBuzz.Api.Tests
{
    using FizzBuzz.Api.Calculators;
    using Xunit;

    public class FizzBuzzCalculatorTests
    {
        private readonly FizzBuzzCalculator sut;

        public FizzBuzzCalculatorTests()
        {
            sut = new FizzBuzzCalculator();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(21)]
        [InlineData(24)]
        [InlineData(27)]
        public async Task Calculate_When_InputIsDivisibleByThreeOnly_Should_ReturnFizz(int input)
        {
            //Arrange

            //Act
            var result = await sut.Calculate(input);

            //Assert
            Assert.Equal("fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(35)]
        [InlineData(40)]
        [InlineData(50)]
        [InlineData(55)]
        public async Task Calculate_When_InputIsDivisibleByFiveOnly_Should_ReturnBuzz(int input)
        {
            //Arrange

            //Act
            var result = await sut.Calculate(input);

            //Assert
            Assert.Equal("buzz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        [InlineData(75)]
        [InlineData(90)]
        [InlineData(105)]
        [InlineData(120)]
        public async Task Calculate_When_InputIsDivisibleByThreeAndFive_Should_ReturnFizzBuzz(int input)
        {
            //Arrange

            //Act
            var result = await sut.Calculate(input);

            //Assert
            Assert.Equal("fizzbuzz", result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(14)]
        public async Task Calculate_When_InputIsNotDivisibleByThreeOrFizz_Should_ReturnEmptyString(int input)
        {
            //Arrange

            //Act
            var result = await sut.Calculate(input);

            //Assert
            Assert.Equal(string.Empty, result);
        }
    }
}