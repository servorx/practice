using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Companies;

public class CreateCompanyHandler : IRequestHandler<CreateCompany, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCompany request, CancellationToken cancellationToken)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(request.CityId, cancellationToken);
        if (city is null)
            throw new InvalidOperationException($"City with Id {request.CityId} does not exist.");

        var company = new Company(
            new EntityName(request.Name),
            new UkNiu(request.UkNiu),
            new Address(request.Address),
            new Email(request.Email),
            city
        );

        await _unitOfWork.Companies.AddAsync(company, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return company.Id;
    }
}
