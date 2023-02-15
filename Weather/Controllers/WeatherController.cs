using Microsoft.AspNetCore.Mvc;
using Weather.App.Services.Interfaces;

namespace Weather.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(
            IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("by-city-id")]
        public async Task<IActionResult> GetByCityId([FromQuery] int id, CancellationToken cancellationToken)
        {
            var result = await _weatherService.GetWeatherByCityId(id, cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("by-location")]
        public async Task<IActionResult> GetByLocation([FromQuery] double latitude, [FromQuery] double longtitude, CancellationToken cancellationToken)
        {
            var result = await _weatherService.GetWeatherFromOpenWeatherByLocation(latitude, longtitude, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}