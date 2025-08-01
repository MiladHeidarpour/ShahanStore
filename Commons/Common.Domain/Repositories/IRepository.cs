using Common.Domain.Bases;

namespace Common.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
}