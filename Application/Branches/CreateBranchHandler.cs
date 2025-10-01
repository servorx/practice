using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Branches;

public class CreateBranchHandler : IRequestHandler<CreateBranch, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBranchHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateBranch request, CancellationToken cancellationToken)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(request.CityId, cancellationToken);
        if (city is null)
            throw new InvalidOperationException($"City with Id {request.CityId} does not exist.");

        var company = await _unitOfWork.Companies.GetByIdAsync(request.CompanyId, cancellationToken);
        if (company is null)
            throw new InvalidOperationException($"Company with Id {request.CompanyId} does not exist.");

        var branch = new Branch(
            new EntityNumber(request.NumberCommercial),
            new Address(request.Address),
            new Email(request.Email),
            new ContactName(request.ContactName),
            new PhoneNumber(request.Phone),
            city,
            company
        );

        await _unitOfWork.Branches.AddAsync(branch, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return branch.Id;
    }
}
