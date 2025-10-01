using Application.Abstractions;
using Domain.ValueObjects;
using MediatR;

namespace Application.Regions;

public class UpdateRegionHandler : IRequestHandler<UpdateRegion, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRegionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateRegion request, CancellationToken cancellationToken)
    {
        var region = await _unitOfWork.Regions.GetByIdAsync(request.Id, cancellationToken);
        if (region is null) return false;

        var country = await _unitOfWork.Countries.GetByIdAsync(request.Id, cancellationToken);
        if (country is null)
            throw new InvalidOperationException($"Country with Id {request.Id} does not exist.");

        region.Name = new EntityName(request.Name);
        region.Country = country;

        var updated = await _unitOfWork.Regions.UpdateAsync(region, cancellationToken);
        if (!updated) return false;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
