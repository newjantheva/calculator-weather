using NewCalculator.Core.Exceptions;
using NewCalculator.Infrastructure.Services.Weather;
using System.Text.Json;
using Tests.Mocks.Weather;

namespace Tests
{

    public class WeatherTests
    {
        [Fact]
        public async Task GetWeatherTemperatureAsync_ValidCity_ReturnsCurrentTemperature()
        {
            //Arrange
            var city = "Holstebro";

            var mockedHttpClientService = new ValidResponseHttpClientService();
            var weatherService = new WeatherService(mockedHttpClientService, null);

            var expected = 0.2;

            //Act
            var actual = await weatherService.GetWeatherTemperatureByCityAsync(city);


            //Assert
            Assert.Equal(expected, actual?.CurrentTemperature);
        }

        [Fact]
        public async Task GetWeatherAsync_EmptyResponse_ThrowsException()
        {
            // Arrange
            var mockedHttpClientService = new EmptyResponseHttpClientService();
            var weatherService = new WeatherService(mockedHttpClientService, null);

            // Act & Assert
            await Assert.ThrowsAsync<JsonException>(async () =>
                await weatherService.GetWeatherTemperatureByCityAsync("SomeCity"));
        }

        [Fact]
        public async Task GetWeatherTemperatureAsync_ErrorResponse_ThrowsException()
        {
            //Arrange
            string city = "FakeCity";

            var mockedHttpClientService = new ErrorResponseHttpClientService();
            var weatherService = new WeatherService(mockedHttpClientService, null);


            //Act + Assert
            await Assert.ThrowsAsync<WeatherTemperatureException>(() => weatherService.GetWeatherTemperatureByCityAsync(city));
        }
    }
}


