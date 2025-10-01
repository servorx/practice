using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Abstractions;

public interface IRegionRepository
{
    Task<Region?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Region?> GetByNameAsync(EntityName name, CancellationToken ct = default);
    Task<IReadOnlyList<Region>> GetAllAsync(CancellationToken ct = default);
    // estos son los metodos de escritura
    Task<int> AddAsync(Region region, CancellationToken ct = default);
    Task<bool> UpdateAsync(Region region, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}