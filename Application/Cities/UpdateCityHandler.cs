using Application.Abstractions;
using Domain.ValueObjects;
using MediatR;

namespace Application.Cities;

public class UpdateCityHandler : IRequestHandler<UpdateCity, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCityHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateCity request, CancellationToken cancellationToken)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(request.Id, cancellationToken);
        if (city is null) return false;

        var region = await _unitOfWork.Regions.GetByIdAsync(request.RegionId, cancellationToken);
        if (region is null)
            throw new InvalidOperationException($"Region with Id {request.RegionId} does not exist.");

        city.Name = new EntityName(request.Name);
        city.Region = region;

        var updated = await _unitOfWork.Cities.UpdateAsync(city, cancellationToken);
        if (!updated) return false;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
