using Application.Abstractions;
using Domain.ValueObjects;
using MediatR;

namespace Application.Companies;

public class UpdateCompanyHandler : IRequestHandler<UpdateCompany, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCompanyHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateCompany request, CancellationToken cancellationToken)
    {
        var company = await _unitOfWork.Companies.GetByIdAsync(request.Id, cancellationToken);
        if (company is null) return false;

        var city = await _unitOfWork.Cities.GetByIdAsync(request.CityId, cancellationToken);
        if (city is null)
            throw new InvalidOperationException($"City with Id {request.CityId} does not exist.");

        company.Name = new EntityName(request.Name);
        company.UkNiu = new UkNiu(request.UkNiu);
        company.Address = new Address(request.Address);
        company.Email = new Email(request.Email);
        company.City = city;

        var updated = await _unitOfWork.Companies.UpdateAsync(company, cancellationToken);
        if (!updated) return false;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
