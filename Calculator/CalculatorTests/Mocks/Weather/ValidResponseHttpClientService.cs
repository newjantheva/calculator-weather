using NewCalculator.Core.Interfaces;

// Not using Moq in this setup cause of:  Moq exfiltrates developer's emails from their development machine and sends them off to third-party remote servers.
// Manually creating mocks for testings purpose.
namespace Tests.Mocks.Weather
{
    public class ValidResponseHttpClientService : IHttpClientService
    {
        public Task<string> GetAsync(string url)
        {
            return Task.FromResult("{\"location\":{\"name\":\"Holstebro\",\"region\":\"Midtjylland\",\"country\":\"Denmark\",\"lat\":56.35,\"lon\":8.6333,\"tz_id\":\"Europe/Copenhagen\",\"localtime_epoch\":1734116924,\"localtime\":\"2024-12-13 20:08\"},\"current\":{\"last_updated_epoch\":1734116400,\"last_updated\":\"2024-12-13 20:00\",\"temp_c\":0.2,\"temp_f\":32.4,\"is_day\":0,\"condition\":{\"text\":\"Mist\",\"icon\":\"//cdn.weatherapi.com/weather/64x64/night/143.png\",\"code\":1030},\"wind_mph\":9.6,\"wind_kph\":15.5,\"wind_degree\":208,\"wind_dir\":\"SSW\",\"pressure_mb\":1022.0,\"pressure_in\":30.18,\"precip_mm\":0.01,\"precip_in\":0.0,\"humidity\":93,\"cloud\":100,\"feelslike_c\":-4.3,\"feelslike_f\":24.3,\"windchill_c\":-0.3,\"windchill_f\":31.4,\"heatindex_c\":3.4,\"heatindex_f\":38.1,\"dewpoint_c\":0.5,\"dewpoint_f\":33.0,\"vis_km\":2.8,\"vis_miles\":1.0,\"uv\":0.0,\"gust_mph\":14.7,\"gust_kph\":23.7}}");
        }
    }
}


