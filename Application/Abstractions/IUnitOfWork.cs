using Domain.Entities;

namespace Application.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation, CancellationToken ct = default);
}
