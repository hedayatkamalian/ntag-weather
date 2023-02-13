using Flurl;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Weather.App.Commands;
using Weather.App.models.OpenWeather;
using Weather.App.Options;
using Weather.App.Services.Interfaces;

namespace Weather.App.Services.Implements
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherApiOptions _openWeatherApiOptions;

        public WeatherService(HttpClient httpClient, IOptions<OpenWeatherApiOptions> openWeatherApiOptions)
        {
            _openWeatherApiOptions = openWeatherApiOptions.Value;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_openWeatherApiOptions.BaseAddress);
        }

        public async Task GetWeatherFromOpenWeatherByLocation(GetWeatherByLocationCommand command, CancellationToken cancellationToken)
        {
            var request = new OpenWeatherRequest
            {
                appId = _openWeatherApiOptions.APIKey,
                lat = command.Latitude,
                lon = command.Longtitude
            };

            var queryString = "".SetQueryParams(request);
            var response = await _httpClient.GetAsync(queryString);

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var openWeatherResponse = JsonConvert.DeserializeObject<OpenWeatherResponse>(jsonString);


        }



    }
}
