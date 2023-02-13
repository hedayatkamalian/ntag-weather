using Microsoft.AspNetCore.Mvc;
using Weather.App.Commands;
using Weather.App.Services.Interfaces;

namespace Weather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetWeatherByCoordinatesQuery(52.5200, 13.4050);
            var result = await _weatherService.GetWeatherFromOpenWeatherByLocation(query, cancellationToken);

            return Ok(result);
        }
    }
}