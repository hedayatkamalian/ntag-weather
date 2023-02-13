namespace Weather.App.models.OpenWeather
{
    public class OpenWeatherRequest
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string appId { get; set; }
    }
}
