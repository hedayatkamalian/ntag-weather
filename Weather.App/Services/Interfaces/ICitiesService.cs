using Weather.App.DTO;
using Weather.App.Queries;

namespace Weather.App.Services.Interfaces
{
    public interface ICitiesService
    {
        Coordinate? GetCityCoordinateById(int id);
        IList<CitySearchResultItem> SearchCityByName(SearchCityByNameQuery query);
    }
}
