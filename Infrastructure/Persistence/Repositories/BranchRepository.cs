using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class BranchRepository(AppDbContext db) : IBranchRepository
{
    public Task<Branch?> GetByIdAsync(int id, CancellationToken ct = default) =>
        db.Branches.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id, ct);

    public Task<Branch?> GetByEntityNumberAsync(EntityNumber numberCommercial, CancellationToken ct = default) =>
        db.Branches.AsNoTracking().FirstOrDefaultAsync(b => b.NumberCommercial == numberCommercial, ct);

    public async Task<IReadOnlyList<Branch>> GetAllAsync(CancellationToken ct = default) =>
        await db.Branches.AsNoTracking().ToListAsync(ct);

    public async Task<int> AddAsync(Branch branch, CancellationToken ct = default)
    {
        await db.Branches.AddAsync(branch, ct);
        await db.SaveChangesAsync(ct);
        return branch.Id;
    }

    public async Task<bool> UpdateAsync(Branch branch, CancellationToken ct = default)
    {
        db.Branches.Update(branch);
        await db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var branch = await db.Branches.FindAsync(new object[] { id }, ct);
        if (branch is null)
            return false;

        db.Branches.Remove(branch);
        await db.SaveChangesAsync(ct);
        return true;
    }
}   