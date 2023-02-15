using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using Weather.App.Options;
using Weather.App.Services.Interfaces;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _citiesService;
        private readonly ApplicationOptions _applicationOptions;

        public CitiesController(ICitiesService citiesService,
            IOptions<ApplicationOptions> applicationOptions)
        {
            _citiesService = citiesService;
            _applicationOptions = applicationOptions.Value;
        }


        [HttpGet("by-name")]
        public IActionResult GetByName([FromQuery][MinLength(3)] string name, CancellationToken cancellationToken)
        {
            name = name.Trim();

            if (string.IsNullOrEmpty(name) || name.Length < _applicationOptions.SearchQueryMinLength)
            {
                return UnprocessableEntity();
            }

            var result = _citiesService.SearchCityByName(name);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
