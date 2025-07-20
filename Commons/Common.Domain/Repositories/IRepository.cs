using Common.Domain.Bases;
using System.Linq.Expressions;

namespace Common.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    
}