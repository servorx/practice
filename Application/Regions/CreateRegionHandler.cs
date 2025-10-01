using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Regions;

public class CreateRegionHandler : IRequestHandler<CreateRegion, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateRegion request, CancellationToken cancellationToken)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(request.CountryId, cancellationToken);
        if (country is null)
            throw new InvalidOperationException($"Country with Id {request.CountryId} does not exist.");

        var region = new Region
        {
            Name = new EntityName(request.Name),
            Country = country
        };

        await _unitOfWork.Regions.AddAsync(region, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return region.Id;
    }
}
