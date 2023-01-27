namespace FizzBuzz.Api.Calculators
{
    public class FizzBuzzCalculator : ICalculator
    {
        public async Task<string> Calculate(int input)
        {
            if (input % 3 == 0 && input % 5 == 0)
            {
                return "fizzbuzz";
            }

            if (input % 3 == 0)
            {
                return "fizz";
            }

            if (input % 5 == 0)
            {
                return "buzz";
            }

            return string.Empty;
        }
    }
}
