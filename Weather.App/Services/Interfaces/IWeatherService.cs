using Weather.App.DTO;

namespace Weather.App.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherResponse?> GetWeatherFromOpenWeatherByLocation(double latitude, double longtitude, CancellationToken cancellationToken);
        Task<WeatherResponse?> GetWeatherByCityId(int cityId, CancellationToken cancellationToken);
    }
}
