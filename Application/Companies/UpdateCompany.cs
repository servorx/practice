using MediatR;

namespace Application.Companies;

public record UpdateCompany(
    int Id,
    string Name,
    int UkNiu,
    string Address,
    string Email,
    int CityId
) : IRequest<bool>;
