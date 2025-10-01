using Api.DTOs.City;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Mappings;

public class CityProfile : Profile
{
    public CityProfile()
    {
        // Entity -> DTO
        CreateMap<City, CityDto>()
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.Region.Id));

        // DTO -> Entity
        CreateMap<CreateCityDto, City>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new EntityName(src.Name)))
            .ForMember(dest => dest.Region, opt => opt.Ignore()); // se asigna en el Handler

        CreateMap<UpdateCityDto, City>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new EntityName(src.Name)))
            .ForMember(dest => dest.Region, opt => opt.Ignore()); // se asigna en el Handler
    }
}
