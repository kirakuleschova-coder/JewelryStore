using System.Text.Json.Serialization;

namespace JewelryStore.Model
{
    public class WeatherDto
    {
        [JsonPropertyName("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }
    }
}
