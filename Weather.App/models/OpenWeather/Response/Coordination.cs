using Newtonsoft.Json;

namespace Weather.App.models.OpenWeather.Response
{
    public class OpenWeatherCoordination
    {
        [JsonProperty("lon")]
        public double Longtitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
