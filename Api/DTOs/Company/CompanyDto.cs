namespace Api.DTOs.Company;

public record CompanyDto(
    int Id,
    string Name,
    int UkNiu,
    string Address,
    string Email,
    int CityId,
    string CityName
);
