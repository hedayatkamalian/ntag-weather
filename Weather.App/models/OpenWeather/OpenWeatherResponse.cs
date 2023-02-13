using Newtonsoft.Json;
using Weather.App.models.OpenWeather.Response;

namespace Weather.App.models.OpenWeather;

public class OpenWeatherResponse
{
    [JsonProperty("coord")]
    public OpenWeatherCoordination Coordination { get; set; }

    [JsonProperty("weather")]
    public IList<WeatherDescriptions> Weather { get; set; }

    [JsonProperty("base")]
    public string Base { get; set; }

    [JsonProperty("main")]
    public OpenWeatherMainData Main { get; set; }

    [JsonProperty("visibility")]
    public int Visibility { get; set; }

    [JsonProperty("wind")]
    public OpenWeatherWind Wind { get; set; }

    [JsonProperty("rain")]
    public OpenWeatherRain Rain { get; set; }

    [JsonProperty("clouds")]
    public OpenWeatherRain Clouds { get; set; }

    [JsonProperty("dt")]
    public string DateTime { get; set; }

    [JsonProperty("system")]
    public OpenWeatherSystem System { get; set; }

    [JsonProperty("timezone")]
    public int TimeZone { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("cod")]
    public int Code { get; set; }
}
