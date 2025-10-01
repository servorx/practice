using MediatR;
using Domain.ValueObjects;

namespace Application.Regions;

public record UpdateRegion(int Id, string Name, int IdCountry) : IRequest<bool>;
