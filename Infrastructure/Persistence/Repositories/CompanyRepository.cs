using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CompanyRepository(AppDbContext db) : ICompanyRepository
{
    public Task<Company?> GetByIdAsync(int id, CancellationToken ct = default) =>
        db.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);

    public Task<Company?> GetByUkNiuAsync(UkNiu ukNiu, CancellationToken ct = default) =>
        db.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.UkNiu == ukNiu, ct);

    public async Task<IReadOnlyList<Company>> GetAllAsync(CancellationToken ct = default) =>
        await db.Companies.AsNoTracking().ToListAsync(ct);

    public async Task<int> AddAsync(Company company, CancellationToken ct = default)
    {
        await db.Companies.AddAsync(company, ct);
        await Task.CompletedTask;
        return company.Id;
    }

    public async Task<bool> UpdateAsync(Company company, CancellationToken ct = default)
    {
        db.Companies.Update(company);
        await Task.CompletedTask;
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var company = await db.Companies.FindAsync(new object[] { id }, ct);
        if (company is null)
            return false;

        db.Companies.Remove(company);
        await Task.CompletedTask;
        return true;
    }
}