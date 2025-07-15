using Common.Domain.Bases;
using System.Linq.Expressions;

namespace Common.Domain.Repositories;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task Add(TEntity _object);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    void Delete(TEntity _object);
    void Detach(TEntity entity);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
    IEnumerable<TEntity> GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    TEntity? GetById(Guid id);
    Task<TEntity?> GetByIdAsync(Guid id, bool track = true);
    IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> expression);
    IQueryable<TEntity> GetQueryable();
    Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    void Update(TEntity _object);
}