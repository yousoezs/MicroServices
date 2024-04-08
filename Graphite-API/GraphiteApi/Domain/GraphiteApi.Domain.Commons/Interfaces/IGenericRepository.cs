using GraphiteApi.Domain.Commons.Services;

namespace GraphiteApi.Domain.Commons.Interfaces;

public interface IGenericRepository<TEntity, in TId> where TEntity : IEntity<TId>
{
	Task<ServiceResponse<TEntity>> GetByIdAsync(TId id);
	Task<ServiceResponse<IEnumerable<TEntity>>> GetAllAsync();
	Task<ServiceResponse<TEntity>> AddAsync(TEntity entity);
	Task<ServiceResponse<TEntity>> UpdateAsync(TEntity entity);
	Task<ServiceResponse<TEntity>> DeleteAsync(TId id);
}