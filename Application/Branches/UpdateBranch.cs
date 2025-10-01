using MediatR;

namespace Application.Branches;

public record UpdateBranch(
    int Id,
    int NumberCommercial,
    string Address,
    string Email,
    string ContactName,
    string Phone,
    int CityId,
    int CompanyId
) : IRequest<bool>;
