using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Abstractions;

public interface IBranchRepository
{
    Task<Branch?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Branch?> GetByEntityNumberAsync(EntityNumber numberCommercial, CancellationToken ct = default);
    Task<IReadOnlyList<Branch>> GetAllAsync(CancellationToken ct = default);
    // estos son los metodos de escritura
    Task<int> AddAsync(Branch branch, CancellationToken ct = default);
    Task<bool> UpdateAsync(Branch branch, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}
