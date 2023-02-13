namespace Weather.App.Types
{
    public class WeatherData
    {
        public float Temperature { get; set; }

        public int AirPresurre { get; set; }
        public int Humidity { get; set; }

        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }

        public float WindSpeed { get; set; }
        public int WindDirection { get; set; }

    }
}
