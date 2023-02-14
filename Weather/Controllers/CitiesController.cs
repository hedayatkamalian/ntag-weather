using Microsoft.AspNetCore.Mvc;
using Weather.App.Queries;
using Weather.App.Services.Interfaces;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name, CancellationToken cancellationToken)
        {
            var result = _citiesService.SearchCityByName(new SearchCityByNameQuery(name));

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
