using Newtonsoft.Json;

namespace Weather.App.models.OpenWeather.Response;

public class WeatherDescriptions
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("main")]
    public string Main { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("icon")]
    public string Icon { get; set; }
}
