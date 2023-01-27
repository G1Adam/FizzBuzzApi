namespace FizzBuzz.Api.Calculators
{
    public interface ICalculator
    {
        public Task<string> Calculate(int input);
    }
}
