using Domain.Entities;

namespace Application.Abstractions;

public interface IUnitOfWork
{
    // implementar cada uno de las interfaces de los repositorios
    ICountryRepository Countries { get; }
    IRegionRepository Regions { get; }
    ICityRepository Cities { get; }
    ICompanyRepository Companies { get; }
    IBranchRepository Branches { get; }
    Task<int> SaveChangesAsync();
    Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation, CancellationToken ct = default);
}
