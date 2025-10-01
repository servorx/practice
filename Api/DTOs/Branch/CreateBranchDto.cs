namespace Api.DTOs.Branch;

public record CreateBranchDto(
    int NumberCommercial,
    string Address,
    string Email,
    string ContactName,
    string Phone,
    int CityId,
    int CompanyId
);
