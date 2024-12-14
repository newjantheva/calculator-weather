namespace NewCalculator.Core.Interfaces
{
    public interface ICalculatorService
    {
        decimal Divide(decimal[] numbers);
        decimal Add(decimal[] numbers);
        decimal Add(decimal number1, decimal number2);
    }
}
