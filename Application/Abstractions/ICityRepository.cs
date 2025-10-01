using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Abstractions;

public interface ICityRepository
{
    Task<City?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<City?> GetByNameAsync(EntityName name, CancellationToken ct = default);
    Task<IReadOnlyList<City>> GetAllAsync(CancellationToken ct = default);
    // estos son los metodos de escritura
    Task<int> AddAsync(City city, CancellationToken ct = default);
    Task<bool> UpdateAsync(City city, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}