using MediatR;

namespace Application.Cities;

public record CreateCity(
    string Name,
    int RegionId
) : IRequest<int>;
