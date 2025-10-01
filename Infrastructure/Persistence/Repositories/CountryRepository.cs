using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CountryRepository(AppDbContext db) : ICountryRepository
{
    public Task<Country?> GetByIdAsync(int id, CancellationToken ct = default) =>
        db.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);

    public Task<Country?> GetByNameAsync(EntityName name, CancellationToken ct = default) =>
        db.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name, ct);

    public async Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken ct = default) =>
        await db.Countries.AsNoTracking().ToListAsync(ct);

    public async Task<int> AddAsync(Country country, CancellationToken ct = default)
    {
        await db.Countries.AddAsync(country, ct);
        await db.SaveChangesAsync(ct);
        return country.Id;
    }

    public async Task<bool> UpdateAsync(Country country, CancellationToken ct = default)
    {
        db.Countries.Update(country);
        await db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var country = await db.Countries.FindAsync(new object[] { id }, ct);
        if (country is null)
            return false;

        db.Countries.Remove(country);
        await db.SaveChangesAsync(ct);
        return true;
    }
}