using GraphiteApi.Domain.Commons.Services;
using GraphiteApi.Order.BusinessLogic.Interfaces;
using GraphiteApi.Order.BusinessLogic.Managers.ActionDelegate;
using GraphiteApi.Order.DataAccess.Contexts;
using GraphiteApi.Order.DataAccess.DataModels;

namespace GraphiteApi.Order.BusinessLogic.Repositories
{
    public abstract class OrderRepositoryTemplate : IOrderRepository
    {
        protected OrderContext _dbContext;

        protected OrderRepositoryTemplate(OrderContext dbContext) 
        {
            _dbContext = dbContext;
            GetClassRef.OnGetDbContext += OnGetDbContext;
        }

        public abstract Task<ServiceResponse<OrderModel>> AddAsync(OrderModel entity);

        public abstract Task<ServiceResponse<OrderModel>> DeleteAsync(Guid id);

        public abstract Task<ServiceResponse<IEnumerable<OrderModel>>> GetAllAsync();

        public abstract Task<ServiceResponse<OrderModel>> GetByIdAsync(Guid id);

        public abstract Task<ServiceResponse<OrderModel>>UpdateAsync(OrderModel entity);

        private void OnGetDbContext(ref OrderContext dbContext)
        {
            dbContext = _dbContext;
        }
    }
}
