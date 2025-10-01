using MediatR;

namespace Application.Companies;

public record CreateCompany(
    string Name,
    int UkNiu,
    string Address,
    string Email,
    int CityId
) : IRequest<int>;
