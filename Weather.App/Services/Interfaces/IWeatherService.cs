using Weather.App.Commands;
using Weather.App.DTO;

namespace Weather.App.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherFromOpenWeatherByLocation(GetWeatherByCoordinatesQuery command, CancellationToken cancellationToken);
    }
}
