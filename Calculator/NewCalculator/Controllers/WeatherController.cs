using Microsoft.AspNetCore.Mvc;
using NewCalculator.Core.Interfaces;
using NewCalculator.Core.Models.Weather;

namespace NewCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        [HttpGet("api/v2/{city}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<WeatherApiResponse>> GetWeatherTemperatureByCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City cannot be empty.");
            }

            var temperatureInfo = await _weatherService.GetWeatherTemperatureByCityAsync(city);

            if (temperatureInfo == null)
            {
                return NotFound($"Weather temperature not found for city: {city}");
            }

            return Ok(temperatureInfo);
        }
    }
}
