using NewCalculator.Core.Interfaces;

// Not using Moq in this setup cause of:  Moq exfiltrates developer's emails from their development machine and sends them off to third-party remote servers.
// Manually creating mocks for testings purpose.

namespace Tests.Mocks.Calculation
{
    public class MockedCalculationService : ICalculatorService
    {
        public decimal Add(decimal[] numbers)
        {
            if (numbers.Length < 2 || numbers.Length > 5)
            {
                throw new ArgumentException("You must provide between 2 and 5 numbers.");
            }

            return numbers.Sum();
        }

        public decimal Add(decimal number1, decimal number2)
        {
            return number1 + number2;
        }

        public decimal Divide(decimal[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                throw new ArgumentException("Division requires at least two numbers.");
            }

            decimal result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");

                }

                result /= numbers[i];
            }


            return result;
        }
    }
}