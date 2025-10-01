namespace Api.DTOs.Branch;

public record BranchDto(
    int Id,
    int NumberCommercial,
    string Address,
    string Email,
    string ContactName,
    string Phone,
    int CityId,
    string CityName,
    int CompanyId,
    string CompanyName
);
