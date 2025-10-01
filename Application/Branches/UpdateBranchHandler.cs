using Application.Abstractions;
using Domain.ValueObjects;
using MediatR;

namespace Application.Branches;

public class UpdateBranchHandler : IRequestHandler<UpdateBranch, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBranchHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateBranch request, CancellationToken cancellationToken)
    {
        var branch = await _unitOfWork.Branches.GetByIdAsync(request.Id, cancellationToken);
        if (branch is null) return false;

        var city = await _unitOfWork.Cities.GetByIdAsync(request.CityId, cancellationToken);
        if (city is null)
            throw new InvalidOperationException($"City with Id {request.CityId} does not exist.");

        var company = await _unitOfWork.Companies.GetByIdAsync(request.CompanyId, cancellationToken);
        if (company is null)
            throw new InvalidOperationException($"Company with Id {request.CompanyId} does not exist.");

        branch.NumberCommercial = new EntityNumber(request.NumberCommercial);
        branch.Address = new Address(request.Address);
        branch.Email = new Email(request.Email);
        branch.ContactName = new ContactName(request.ContactName);
        branch.Phone = new PhoneNumber(request.Phone);
        branch.City = city;
        branch.Company = company;

        var updated = await _unitOfWork.Branches.UpdateAsync(branch, cancellationToken);
        if (!updated) return false;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
