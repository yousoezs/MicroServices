using GraphiteApi.Order.BusinessLogic.Interfaces;
using GraphiteApi.Order.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphiteApi.Order.BusinessLogic.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private OrderContext _dbContext;

        public IOrderRepository OrderRepository { get; }
        public UnitOfWork(OrderContext context)
        {
            _dbContext = context;

            OrderRepository = new OrderRepository(_dbContext);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
