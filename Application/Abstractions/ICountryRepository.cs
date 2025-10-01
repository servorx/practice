using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Abstractions;

public interface ICountryRepository
{
    Task<Country?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Country?> GetByNameAsync(EntityName name, CancellationToken ct = default);
    Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken ct = default);
    // estos son los metodos de escritura
    Task<int> AddAsync(Country country, CancellationToken ct = default);
    Task<bool> UpdateAsync(Country country, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}