namespace Api.DTOs.Company;

public record CreateCompanyDto(
    string Name,
    int UkNiu,
    string Address,
    string Email,
    int CityId
);
