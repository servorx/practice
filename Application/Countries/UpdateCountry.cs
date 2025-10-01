using Domain.ValueObjects;
using MediatR;

namespace Application.Countries;

public record UpdateCountry(int Id, string Name) : IRequest<bool>;
