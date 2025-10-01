using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Abstractions;

public interface ICompanyRepository
{
    Task<Company> GetByIdAsync(int id);
    Task<Company> GetByUkNiuAsync(UkNiu ukNiu);
    Task<Company> AddAsync(Company company);
    Task<Company> UpdateAsync(Company company);
    Task<bool> DeleteAsync(int id);
}