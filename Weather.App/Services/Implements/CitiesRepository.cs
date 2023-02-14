using Microsoft.Extensions.Options;
using Weather.App.Entities;
using Weather.App.Options;
using Weather.App.Services.Interfaces;

namespace Weather.App.Services.Implements;

public class CitiesRepository : ICitiesRepository
{
    private readonly SampleDataOptions _sampleDataOptions;
    private readonly ApplicationOptions _applicationOptions;

    public CitiesRepository(
        IOptions<ApplicationOptions> applicationOptions,
        IOptions<SampleDataOptions> sampleDataOptions)
    {
        _sampleDataOptions = sampleDataOptions.Value;
        _applicationOptions = applicationOptions.Value;
    }


    public IList<City> SearchByName(string query)
    {
        return _sampleDataOptions.Cities
            .Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            .Take(_applicationOptions.SearchQueryLimit)
            .ToList();
    }

    public City? GetById(int id)
    {
        return _sampleDataOptions.Cities
            .FirstOrDefault(p => p.Id == id);
    }
}
