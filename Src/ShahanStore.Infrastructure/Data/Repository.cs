using Common.Domain.Bases;

namespace ShahanStore.Infrastructure.Data;

public class Repository<TEntity>(AppDbContext context)
    where TEntity : BaseEntity
{
    protected readonly AppDbContext Context = context;

    public void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }
}