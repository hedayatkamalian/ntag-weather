using Newtonsoft.Json;

namespace Weather.App.models.OpenWeather.Response;

public class OpenWeatherRain
{
    [JsonProperty("1h")]
    public float Amount { get; set; }
}
