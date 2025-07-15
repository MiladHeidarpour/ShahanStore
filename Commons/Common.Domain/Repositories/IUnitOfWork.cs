namespace Common.Domain.Repositories;

public interface IUnitOfWork
{
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task BeginTransaction();
    Task<int> CommitTransaction();
    Task RollbackTransaction();
}