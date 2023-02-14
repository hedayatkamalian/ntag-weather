using Weather.App.Entities;

namespace Weather.App.Services.Interfaces
{
    public interface ICitiesRepository
    {
        IList<City> SearchByName(string query);
        City? GetById(int id);
    }
}
