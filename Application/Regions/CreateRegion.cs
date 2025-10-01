using Domain.ValueObjects;
using MediatR;

namespace Application.Regions;

public record CreateRegion(
    string Name,
    int CountryId
) : IRequest<int>;
