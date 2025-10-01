using Domain.ValueObjects;
using MediatR;

namespace Application.Countries;

public record CreateCountry(
    string Name
) : IRequest<int>;
