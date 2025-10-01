using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Cities;

public class CreateCityHandler : IRequestHandler<CreateCity, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCityHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCity request, CancellationToken cancellationToken)
    {
        var region = await _unitOfWork.Regions.GetByIdAsync(request.RegionId, cancellationToken);
        if (region is null)
            throw new InvalidOperationException($"Region with Id {request.RegionId} does not exist.");

        var city = new City(
            new EntityName(request.Name),
            region
        );

        await _unitOfWork.Cities.AddAsync(city, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return city.Id;
    }
}
