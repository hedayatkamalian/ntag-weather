using AutoMapper;
using Flurl;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Weather.App.DTO;
using Weather.App.models.OpenWeather;
using Weather.App.Options;
using Weather.App.Services.Interfaces;

namespace Weather.App.Services.Implements;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly ICitiesService _citiesService;
    private readonly IMapper _mapper;
    private readonly OpenWeatherApiOptions _openWeatherApiOptions;

    public WeatherService(
        HttpClient httpClient,
        IOptions<OpenWeatherApiOptions> openWeatherApiOptions,
        ICitiesService citiesService,
        IMapper mapper)
    {
        _openWeatherApiOptions = openWeatherApiOptions.Value;
        _httpClient = httpClient;
        _citiesService = citiesService;
        _mapper = mapper;
        _httpClient.BaseAddress = new Uri(_openWeatherApiOptions.BaseAddress);
    }

    public async Task<WeatherResponse?> GetWeatherFromOpenWeatherByLocation(double latitude, double longtitude, CancellationToken cancellationToken)
    {
        var request = new OpenWeatherRequest
        {
            appId = _openWeatherApiOptions.APIKey,
            lat = latitude,
            lon = longtitude,
            units = _openWeatherApiOptions.Units
        };

        var queryString = "".SetQueryParams(request);
        var response = await _httpClient.GetAsync(queryString);

        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var openWeatherResponse = JsonConvert.DeserializeObject<OpenWeatherResponse>(jsonString);

        return _mapper.Map<WeatherResponse>(openWeatherResponse);
    }

    public async Task<WeatherResponse?> GetWeatherByCityId(int cityId, CancellationToken cancellationToken)
    {
        var city = _citiesService.GetCityById(cityId);

        if (city is null)
            return null;

        return await GetWeatherFromOpenWeatherByLocation(city.Latitude, city.Longtitude, cancellationToken);

    }
}
