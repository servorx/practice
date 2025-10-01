using Api.DTOs.Branch;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Mappings;

public class BranchProfile : Profile
{
    public BranchProfile()
    {
        // Entity -> DTO
        CreateMap<Branch, BranchDto>()
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.City.Id))
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id));

        // DTO -> Entity
        CreateMap<CreateBranchDto, Branch>()
            .ForMember(dest => dest.NumberCommercial, opt => opt.MapFrom(src => new EntityNumber(src.NumberCommercial)))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address(src.Address)))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => new ContactName(src.ContactName)))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => new PhoneNumber(src.Phone)))
            .ForMember(dest => dest.City, opt => opt.Ignore())    // se resuelve en el Handler
            .ForMember(dest => dest.Company, opt => opt.Ignore()); // se resuelve en el Handler

        CreateMap<UpdateBranchDto, Branch>()
            .ForMember(dest => dest.NumberCommercial, opt => opt.MapFrom(src => new EntityNumber(src.NumberCommercial)))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address(src.Address)))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => new ContactName(src.ContactName)))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => new PhoneNumber(src.Phone)))
            .ForMember(dest => dest.City, opt => opt.Ignore())
            .ForMember(dest => dest.Company, opt => opt.Ignore());
    }
}
