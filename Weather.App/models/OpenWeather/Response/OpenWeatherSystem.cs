using Newtonsoft.Json;

namespace Weather.App.models.OpenWeather.Response
{
    public class OpenWeatherSystem
    {

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }

}
