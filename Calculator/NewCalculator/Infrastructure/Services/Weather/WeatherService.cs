using Microsoft.Extensions.Options;
using NewCalculator.Core.Exceptions;
using NewCalculator.Core.Interfaces;
using NewCalculator.Core.Models.Weather;
using NewCalculator.Options;
using System.Text.Json;

namespace NewCalculator.Infrastructure.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherApiKeyOptions _weatherApiKeyOptions;
        private readonly IHttpClientService _httpClientService;

        public WeatherService(IHttpClientService httpClientService, IOptions<WeatherApiKeyOptions> weatherApiKeyOptions)
        {
            _httpClientService = httpClientService;
            _weatherApiKeyOptions = weatherApiKeyOptions.Value;
        }

        public async Task<WeatherApiResponse?> GetWeatherTemperatureByCityAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City name cannot be null or empty.", nameof(city));
            }

            var baseAddress = "https://api.weatherapi.com";
            var url = $"{baseAddress}/v1/current.json?key={_weatherApiKeyOptions.WeatherApiKey}&q={city}&aqi=no";
            var response = await _httpClientService.GetAsync(url);

            var weatherData = JsonSerializer.Deserialize<WeatherApiRequest>(response);

            if (weatherData?.Current == null)
            {
                throw new WeatherTemperatureException();
            }

            return new WeatherApiResponse { CurrentTemperature = weatherData?.Current?.TempC ?? null };
        }
    }
}
