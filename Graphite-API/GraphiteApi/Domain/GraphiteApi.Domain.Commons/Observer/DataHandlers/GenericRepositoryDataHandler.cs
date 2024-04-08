using GraphiteApi.Domain.Commons.Interfaces;
using GraphiteApi.Domain.Commons.Services;
using System;

namespace GraphiteApi.Domain.Commons.Observer.DataHandlers
{
    public static class GenericRepositoryDataHandler<TRepository, TEntity, TId>
        where TRepository : IGenericRepository<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        #region Events

        public static event Func<TEntity, Task<ServiceResponse<TEntity>>> OnEntityCreated;
        public static event Func<TId, Task<ServiceResponse<TEntity>>> OnEntityDeleted;
        public static event Func<TEntity, Task<ServiceResponse<TEntity>>> OnEntityUpdated;
        public static event Func<TId, Task<ServiceResponse<TEntity>>> OnFetchEntityId;
        public static event Func<Task<ServiceResponse<IEnumerable<TEntity>>>> OnGetAllEntities;

        #endregion

        #region Invokes

        public static Task<ServiceResponse<TEntity>> EntityCreated(TRepository genericRepository, TEntity entity) => OnEntityCreated?.Invoke(entity);
        public static Task<ServiceResponse<TEntity>> EntityDeleted(TRepository genericRepository, TId entity) => OnEntityDeleted?.Invoke(entity);
        public static Task<ServiceResponse<TEntity>> EntityUpdated(TRepository genericRepository, TEntity entity) => OnEntityUpdated?.Invoke(entity);
        public static Task<ServiceResponse<TEntity>> FetchEntityId(TRepository genericRepository, TId id) => OnFetchEntityId?.Invoke(id);
        public static Task<ServiceResponse<IEnumerable<TEntity>>> GetAllEntities(TRepository repository) => OnGetAllEntities?.Invoke();
        #endregion
    }
}
