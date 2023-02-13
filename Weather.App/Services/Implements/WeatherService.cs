using AutoMapper;
using Flurl;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Weather.App.Commands;
using Weather.App.DTO;
using Weather.App.models.OpenWeather;
using Weather.App.Options;
using Weather.App.Services.Interfaces;

namespace Weather.App.Services.Implements
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly OpenWeatherApiOptions _openWeatherApiOptions;

        public WeatherService(
            HttpClient httpClient,
            IOptions<OpenWeatherApiOptions> openWeatherApiOptions,
            IMapper mapper)
        {
            _openWeatherApiOptions = openWeatherApiOptions.Value;
            _httpClient = httpClient;
            _mapper = mapper;
            _httpClient.BaseAddress = new Uri(_openWeatherApiOptions.BaseAddress);
        }

        public async Task<WeatherResponse> GetWeatherFromOpenWeatherByLocation(GetWeatherByCoordinatesQuery command, CancellationToken cancellationToken)
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

            return _mapper.Map<WeatherResponse>(openWeatherResponse);
        }



    }
}
