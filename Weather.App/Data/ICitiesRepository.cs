using Weather.App.Entities;

namespace Weather.App.Data
{
    public interface ICitiesRepository
    {
        IList<City> SearchByName(string query);
        City? GetById(int id);
    }
}
