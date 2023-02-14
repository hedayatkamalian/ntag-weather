using Microsoft.AspNetCore.Mvc;
using Weather.App.Commands;
using Weather.App.Services.Interfaces;

namespace Weather.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(
            ILogger<WeatherController> logger,
            IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string q, CancellationToken cancellationToken)
        {
            var query = new GetWeatherByCoordinatesQuery(52.5200, 13.4050);
            var result = await _weatherService.GetWeatherFromOpenWeatherByLocation(query, cancellationToken);

            return Ok(result);
        }
    }
}