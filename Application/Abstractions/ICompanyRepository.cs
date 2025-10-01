using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Abstractions;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Company?> GetByUkNiuAsync(UkNiu ukNiu, CancellationToken ct = default);
    Task<IReadOnlyList<Company>> GetAllAsync(CancellationToken ct = default);
    // estos son los metodos de escritura
    Task<int> AddAsync(Company company, CancellationToken ct = default);
    Task<bool> UpdateAsync(Company company, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}