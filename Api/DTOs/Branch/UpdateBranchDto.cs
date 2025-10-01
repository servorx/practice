namespace Api.DTOs.Branch;

public record UpdateBranchDto(
    int Id,
    int NumberCommercial,
    string Address,
    string Email,
    string ContactName,
    string Phone,
    int CityId,
    int CompanyId
);
