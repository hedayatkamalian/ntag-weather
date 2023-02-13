using Newtonsoft.Json;

namespace Weather.App.models.OpenWeather.Response
{
    public class OpenWeatherClouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
