using Newtonsoft.Json;

namespace Weather.App.models.OpenWeather.Response;

public class OpenWeatherWind
{

    [JsonProperty("speed")]
    public float Speed { get; set; }

    [JsonProperty("deg")]
    public int Degree { get; set; }

    [JsonProperty("gust")]
    public float Gust { get; set; }
}
