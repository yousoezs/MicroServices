using GraphiteApi.Domain.Commons.Interfaces;
using GraphiteApi.Order.DataAccess.DataModels;

namespace GraphiteApi.Order.BusinessLogic.Interfaces
{
    public interface IOrderRepository : IGenericRepository<OrderModel, Guid>
    {
    }
}
