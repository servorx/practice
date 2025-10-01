using MediatR;

namespace Application.Cities;

public record UpdateCity(
    int Id,
    string Name,
    int RegionId
) : IRequest<bool>;
