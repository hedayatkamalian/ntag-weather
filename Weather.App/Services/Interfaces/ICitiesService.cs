using Weather.App.DTO;
using Weather.App.Entities;

namespace Weather.App.Services.Interfaces
{
    public interface ICitiesService
    {
        Coordinate? GetCityCoordinateById(int id);
        IList<CitySearchResultItem> SearchCityByName(string query);
        City? GetCityById(int id);
    }
}
