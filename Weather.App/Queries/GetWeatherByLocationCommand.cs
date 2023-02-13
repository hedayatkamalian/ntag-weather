namespace Weather.App.Commands;

public class GetWeatherByCoordinatesQuery
{
    public GetWeatherByCoordinatesQuery(double latitude, double longtitude)
    {
        Latitude = latitude;
        Longtitude = longtitude;
    }

    public double Latitude { get; set; }
    public double Longtitude { get; set; }
}
