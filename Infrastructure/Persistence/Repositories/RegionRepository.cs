using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RegionRepository(AppDbContext db) : IRegionRepository
{
    public Task<Region?> GetByIdAsync(int id, CancellationToken ct = default) =>
        db.Regions.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id, ct);

    public Task<Region?> GetByNameAsync(EntityName name, CancellationToken ct = default) =>
        db.Regions.AsNoTracking().FirstOrDefaultAsync(r => r.Name == name, ct);

    public async Task<IReadOnlyList<Region>> GetAllAsync(CancellationToken ct = default) =>
        await db.Regions.AsNoTracking().ToListAsync(ct);

    public async Task<int> AddAsync(Region region, CancellationToken ct = default)
    {
        await db.Regions.AddAsync(region, ct);
        await Task.CompletedTask;
        return region.Id;
    }

    public async Task<bool> UpdateAsync(Region region, CancellationToken ct = default)
    {
        db.Regions.Update(region);
        await Task.CompletedTask;
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var region = await db.Regions.FindAsync(new object[] { id }, ct);
        if (region is null)
            return false;

        db.Regions.Remove(region);
        await Task.CompletedTask;
        return true;
    }
}