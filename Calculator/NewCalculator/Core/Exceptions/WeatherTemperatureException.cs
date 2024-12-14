namespace NewCalculator.Core.Exceptions
{
    public class WeatherTemperatureException : Exception
    {
        public WeatherTemperatureException()
            : base("An error occurred while fetching the weather temperature.") { }

        public WeatherTemperatureException(string message)
            : base(message) { }

        public WeatherTemperatureException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
