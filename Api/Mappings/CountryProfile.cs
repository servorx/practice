using Api.DTOs.Country;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Mappings;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        // Entity -> DTO
        CreateMap<Country, CountryDto>();

        // DTO -> Entity
        CreateMap<CreateCountryDto, Country>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new EntityName(src.Name)));

        CreateMap<UpdateCountryDto, Country>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new EntityName(src.Name)));
    }
}
