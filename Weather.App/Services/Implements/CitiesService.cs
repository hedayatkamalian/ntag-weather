using AutoMapper;
using Weather.App.Data;
using Weather.App.DTO;
using Weather.App.Entities;
using Weather.App.Services.Interfaces;

namespace Weather.App.Services.Implements
{
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IMapper _mapper;

        public CitiesService(ICitiesRepository citiesRepository,
            IMapper mapper)
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
        }

        public IList<CitySearchResultItem> SearchCityByName(string query)
        {
            var result = _citiesRepository.SearchByName(query);
            return _mapper.Map<IList<CitySearchResultItem>>(result);
        }

        public Coordinate? GetCityCoordinateById(int id)
        {
            var city = _citiesRepository.GetById(id);
            return _mapper.Map<Coordinate?>(city);
        }

        public City? GetCityById(int id)
        {
            return _citiesRepository.GetById(id);
        }
    }
}
