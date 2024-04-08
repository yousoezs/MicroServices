using GraphiteApi.Domain.Commons.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphiteApi.Domain.Commons.Interfaces
{
    public interface IObservableManager<TRepository, TEntity, TId> 
        where TRepository : IGenericRepository<TEntity, TId> 
        where TEntity : IEntity<TId>
    {
        TEntity Entity { get; set; }
        void OnEventSubscription();
        void OnEventUnSubscription();
        Task<ServiceResponse<TEntity>> OnAddEntity(TEntity entity);
        Task<ServiceResponse<TEntity>> OnUpdateEntity(TEntity entity);
        Task<ServiceResponse<TEntity>> OnDeleteEntity(TId entity);
        Task<ServiceResponse<TEntity>> OnGetOrderId(TId id);
        Task<ServiceResponse<IEnumerable<TEntity>>> OnGetAllOrder();
    }
}
