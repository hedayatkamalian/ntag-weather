using Newtonsoft.Json;

namespace Weather.App.models.OpenWeather.Response
{
    public class OpenWeatherMainData
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }

        [JsonProperty("feels_like")]
        public float FeelsLike { get; set; }

        [JsonProperty("temp_max")]
        public float MaxTemperature { get; set; }

        [JsonProperty("temp_min")]
        public float MinTemperature { get; set; }

        [JsonProperty("pressure")]
        public float Pressure { get; set; }

        [JsonProperty("humidity")]
        public float Humidity { get; set; }

        [JsonProperty("sea_level")]
        public float SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public float GroundLevel { get; set; }
    }
}
