namespace GraphiteApi.Domain.Commons.Interfaces;

public interface IGenericUnitOfWork<TRepository,TEntity, TId> : IDisposable 
    where TRepository : IGenericRepository<TEntity, TId>
        where TEntity : IEntity<TId>
{
    TRepository Repository { get; set; }

    Task SaveAsync();
}