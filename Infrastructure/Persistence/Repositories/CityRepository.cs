using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CityRepository(AppDbContext db) : ICityRepository
{
    public Task<City?> GetByIdAsync(int id, CancellationToken ct = default) =>
        db.Cities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);

    public Task<City?> GetByNameAsync(EntityName name, CancellationToken ct = default) =>
        db.Cities.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name, ct);

    public async Task<IReadOnlyList<City>> GetAllAsync(CancellationToken ct = default) =>
        await db.Cities.AsNoTracking().ToListAsync(ct);

    public async Task<int> AddAsync(City city, CancellationToken ct = default)
    {
        await db.Cities.AddAsync(city, ct);
        await db.SaveChangesAsync(ct);
        return city.Id;
    }

    public async Task<bool> UpdateAsync(City city, CancellationToken ct = default)
    {
        db.Cities.Update(city);
        await db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var city = await db.Cities.FindAsync(new object[] { id }, ct);
        if (city is null)
            return false;

        db.Cities.Remove(city);
        await db.SaveChangesAsync(ct);
        return true;
    }
}
