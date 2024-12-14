namespace NewCalculator.Core.Models.Calculator
{
    public class CalculationResult
    {
        public string Operation { get; }
        public object Input { get; }
        public object? Result { get; }  
        public string? ErrorMessage { get; }

        public CalculationResult(string operation, object input, object? result = null, string? errorMessage = null)
        {
            Operation = operation;
            Input = input;
            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}
