using NewCalculator.Core.Models.Weather;

namespace NewCalculator.Core.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherApiResponse?> GetWeatherTemperatureByCityAsync(string city);
    }
}
