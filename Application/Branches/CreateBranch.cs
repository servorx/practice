using MediatR;

namespace Application.Branches;

public record CreateBranch(
    int NumberCommercial,
    string Address,
    string Email,
    string ContactName,
    string Phone,
    int CityId,
    int CompanyId
) : IRequest<int>;
