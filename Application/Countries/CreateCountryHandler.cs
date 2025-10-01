using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Countries;

public class CreateCountryHandler : IRequestHandler<CreateCountry, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCountryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCountry request, CancellationToken cancellationToken)
    {
        var country = new Country
        {
            Name = new EntityName(request.Name)
        };

        await _unitOfWork.Countries.AddAsync(country, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return country.Id;
    }
}
