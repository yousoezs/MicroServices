using GraphiteApi.Domain.Commons.Observer.DataHandlers;
using GraphiteApi.Domain.Commons.Services;
using GraphiteApi.Order.DataAccess.Contexts;
using GraphiteApi.Order.DataAccess.DataModels;

namespace GraphiteApi.Order.BusinessLogic.Repositories
{
    public class OrderRepository : OrderRepositoryTemplate
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext) { }

        public override async Task<ServiceResponse<OrderModel>> AddAsync(OrderModel entity) => await GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.EntityCreated(this, entity);

        public override async Task<ServiceResponse<OrderModel>> DeleteAsync(Guid id) => await GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.EntityDeleted(this, id);

        public override async Task<ServiceResponse<IEnumerable<OrderModel>>> GetAllAsync() => await GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.GetAllEntities(this);

        public override async Task<ServiceResponse<OrderModel>> GetByIdAsync(Guid id) => await GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.FetchEntityId(this, id);

        public override async Task<ServiceResponse<OrderModel>> UpdateAsync(OrderModel entity) => await GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.EntityUpdated(this, entity);

        #region Event Methods



        #endregion
    }
}
