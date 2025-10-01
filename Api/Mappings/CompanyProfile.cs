using Api.DTOs.Company;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Mappings;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        // Entity -> DTO
        CreateMap<Company, CompanyDto>()
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.City.Id));

        // DTO -> Entity
        CreateMap<CreateCompanyDto, Company>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new EntityName(src.Name)))
            .ForMember(dest => dest.UkNiu, opt => opt.MapFrom(src => new UkNiu(src.UkNiu)))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address(src.Address)))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
            .ForMember(dest => dest.City, opt => opt.Ignore()); // asignar en el Handler

        CreateMap<UpdateCompanyDto, Company>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new EntityName(src.Name)))
            .ForMember(dest => dest.UkNiu, opt => opt.MapFrom(src => new UkNiu(src.UkNiu)))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address(src.Address)))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
            .ForMember(dest => dest.City, opt => opt.Ignore()); // asignar en el Handler
    }
}
