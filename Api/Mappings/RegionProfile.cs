using Api.DTOs.Region;
using AutoMapper;
using Domain.Entities;

namespace Api.Mappings;

public class RegionProfile : Profile
{
    public RegionProfile()
    {
        // Entity -> DTO
        CreateMap<Region, RegionDto>()
            // se usa el forMember para mapear propiedades que no tienen el mismo nombre en el DTO y que se necesitan mapear relaciones
            .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.Id));

        // DTO -> Entity
        CreateMap<CreateRegionDto, Region>()
        // el opt significa que se usa el constructor con parámetros
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new Domain.ValueObjects.EntityName(src.Name)))
            .ForMember(dest => dest.Country, opt => opt.Ignore()); // se asigna en el handler con UnitOfWork

        CreateMap<UpdateRegionDto, Region>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new Domain.ValueObjects.EntityName(src.Name)))
            .ForMember(dest => dest.Country, opt => opt.Ignore()); // también se maneja en el handler
    }
}
