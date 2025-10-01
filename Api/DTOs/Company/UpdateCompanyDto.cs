namespace Api.DTOs.Company;

public record UpdateCompanyDto(
    int Id,
    string Name,
    int UkNiu,
    string Address,
    string Email,
    int CityId
);
