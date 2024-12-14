using Tests.Mocks.Calculation;

namespace Tests
{
    public class DivisionTest
    {
        [Fact]
        public void DivideNumbersGivesCorrectResult()
        {
            var service = new MockedCalculationService();

            var result = service.Divide([10, 5]);

            Assert.Equal(2, result);
        }

        [Fact]
        public void DivideByZeroThrowsException()
        {
            // Arrange
            var service = new MockedCalculationService();

            // Act & Assert
            var exception = Assert.Throws<DivideByZeroException>(() => service.Divide([10, 0]));
            Assert.Equal("Cannot divide by zero.", exception.Message);
        }

        [Fact]
        public void DivideSingleNumberReturnsSameNumber()
        {
            // Arrange
            var service = new MockedCalculationService();

            // Act + Assert
            var exception = Assert.Throws<ArgumentException>(() => service.Divide([10]));
            Assert.Equal("Division requires at least two numbers.", exception.Message);
        }

        [Fact]
        public void DivideEmptyArrayThrowsArgumentException()
        {
            // Arrange
            var service = new MockedCalculationService();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => service.Divide([]));
            Assert.Equal("Division requires at least two numbers.", exception.Message);
        }
    }
}