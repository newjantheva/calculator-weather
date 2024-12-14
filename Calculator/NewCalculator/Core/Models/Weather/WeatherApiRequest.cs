using System.Text.Json.Serialization;

namespace NewCalculator.Core.Models.Weather
{
    public class WeatherApiRequest
    {
        [JsonPropertyName("location")]
        public Location? Location { get; set; }

        [JsonPropertyName("current")]
        public Current? Current { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public class Current
    {
        [JsonPropertyName("temp_c")]
        public double? TempC { get; set; }

        [JsonPropertyName("temp_f")]
        public double? TempF { get; set; }
    }
}