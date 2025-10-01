using Application.Abstractions;
using Application.Countries;
using Domain.ValueObjects;
using MediatR;

namespace Application.Countries;

public class UpdateCountryHandler : IRequestHandler<UpdateCountry, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCountryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateCountry request, CancellationToken cancellationToken)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(request.Id, cancellationToken);
        if (country is null) return false;

        country.Name = new EntityName(request.Name);

        var updated = await _unitOfWork.Countries.UpdateAsync(country, cancellationToken);
        if (!updated) return false;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

}
