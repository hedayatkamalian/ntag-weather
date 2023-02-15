using AutoMapper;
using Weather.App.DTO;
using Weather.App.Entities;
using Weather.App.models.OpenWeather;

namespace Weather.App.Mapper;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<OpenWeatherResponse, WeatherResponse>()
            .ForMember(dst => dst.Temperature, option => option.MapFrom(src => src.Main.Temperature))
            .ForMember(dst => dst.MaxTemperature, option => option.MapFrom(src => src.Main.MaxTemperature))
            .ForMember(dst => dst.MinTemperature, option => option.MapFrom(src => src.Main.MinTemperature))
            .ForMember(dst => dst.AirPresurre, option => option.MapFrom(src => src.Main.Pressure))
            .ForMember(dst => dst.Humidity, option => option.MapFrom(src => src.Main.Humidity))
            .ForMember(dst => dst.WindSpeed, option => option.MapFrom(src => src.Wind.Speed))
            .ForMember(dst => dst.WindDirection, option => option.MapFrom(src => src.Wind.Degree))
            .ForMember(dst => dst.Description, option => option.MapFrom(src => src.Weather.First().Description))
            .ForMember(dst => dst.Name, option => option.MapFrom(src => src.Name))
            .ForMember(dst => dst.Icon, option => option.MapFrom(src => src.Weather.First().Icon));

        CreateMap<City, CitySearchResultItem>()
            .ForMember(dst => dst.Id, option => option.MapFrom(src => src.Id))
            .ForMember(dst => dst.Name, option => option.MapFrom(src => src.Name));

        CreateMap<City, Coordinate>();
    }
}
