using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ICountryRepository? _countryRepository;
    public IRegionRepository? _regionRepository;
    public ICityRepository? _cityRepository;
    public ICompanyRepository? _companyRepository;
    public IBranchRepository? _branchRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public Task<int> SaveChangesAsync(CancellationToken ct = default) =>
        _context.SaveChangesAsync(ct);

    public async Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation, CancellationToken ct = default)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(ct);
        try
        {
            await operation(ct);
            await _context.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);
        }
        catch
        {
            await transaction.RollbackAsync(ct);
            throw;
        }
    }
    // implementar cada uno de los repositorios
    public ICountryRepository Countries => _countryRepository ??= new CountryRepository(_context);
    public IRegionRepository Regions => _regionRepository ??= new RegionRepository(_context);
    public ICityRepository Cities => _cityRepository ??= new CityRepository(_context);
    public ICompanyRepository Companies => _companyRepository ??= new CompanyRepository(_context);
    public IBranchRepository Branches => _branchRepository ??= new BranchRepository(_context);
}