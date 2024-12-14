using OldCalculator.Controllers;
using OldCalculator.Models;
using Tests.Mocks.Calculation;

namespace Tests
{
    public class AdditionTest
    {
        //Test from old calculator:
        [Fact]
        public void AddingNumbersGivesCorrectResult()
        {
            var calculator = new CalculatorController();

            var result = calculator.Addition(new CalculationRequest { Number1 = 1, Number2 = 2 });

            Assert.Equal(3, result.Result);
        }

        //Below is updated tests
        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(-1, -1, -2)]
        public void AddNumbersGivesCorrectResult(int a, int b, int expected)
        {
            // Arrange
            var service = new MockedCalculationService();

            // Act
            var actual = service.Add(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(1, 1, "The result of adding 1 and 1 is 2")]
        [InlineData(-2, 3, "The result of adding -2 and 3 is 1")]
        [InlineData(0, 0, "The result of adding 0 and 0 is 0")]
        public void AddNumbersReturnsExpectedMessage(int a, int b, string expectedMessage)
        {
            // Arrange
            var service = new MockedCalculationService();

            // Act
            var result = service.Add(a, b);
            var message = $"The result of adding {a} and {b} is {result}";

            // Assert
            Assert.Equal(expectedMessage, message);
        }
    }
}