using GraphiteApi.Domain.Commons.Interfaces;
using GraphiteApi.Domain.Commons.Observer.DataHandlers;
using GraphiteApi.Domain.Commons.Services;
using GraphiteApi.Order.BusinessLogic.Managers.ActionDelegate;
using GraphiteApi.Order.BusinessLogic.Repositories;
using GraphiteApi.Order.DataAccess.Contexts;
using GraphiteApi.Order.DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;

namespace GraphiteApi.Order.BusinessLogic.Managers
{
    public class OrderRepositoryManager : IObservableManager<OrderRepository, OrderModel, Guid>
    {
        private static OrderRepositoryManager _instance = new();
        private bool IsActive => _instance is not null;
        public OrderModel Entity { get; set; }

        public void OnEventSubscription()
        {
            if (!IsActive) return;

            Console.WriteLine("Subscribing to events");
            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnEntityCreated += OnAddEntity;
            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnEntityDeleted += OnDeleteEntity;
            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnEntityUpdated += OnUpdateEntity;
            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnFetchEntityId += OnGetOrderId;
            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnGetAllEntities += OnGetAllOrder;
        }

        public void OnEventUnSubscription()
        {
            if (!IsActive) return;

            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnEntityCreated -= OnAddEntity;
            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnEntityDeleted -= OnDeleteEntity;
            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnEntityUpdated -= OnUpdateEntity;
            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnFetchEntityId -= OnGetOrderId;
            GenericRepositoryDataHandler<OrderRepository, OrderModel, Guid>.OnGetAllEntities -= OnGetAllOrder;
        }
        #region Event Methods
        public async Task<ServiceResponse<OrderModel>> OnAddEntity(OrderModel entity)
        {
            OrderContext dbContext = default;
            GetClassRef.GetDbContext(ref dbContext!);

            if (entity is null) return new ServiceResponse<OrderModel>(false, null, "No Order");

            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            for (int i = 0; i < entity.OrderDetails.Count; i++)
            {
                entity.OrderDetails.ToList()[i].CreatedDate = DateTime.UtcNow;
                entity.OrderDetails.ToList()[i].UpdatedDate = DateTime.UtcNow;
            }

            await dbContext.AddAsync(entity);

            return new ServiceResponse<OrderModel>(true, entity, "Order Added");
        }

        public async Task<ServiceResponse<OrderModel>> OnDeleteEntity(Guid entity)
        {
            OrderContext dbContext = default;
            GetClassRef.GetDbContext(ref dbContext!);

            var orderToDelete = await dbContext.Orders.FirstOrDefaultAsync(e => e.Id.Equals(entity));

            dbContext.Orders.Remove(orderToDelete);

            return new ServiceResponse<OrderModel>(true, null, "Order Deleted");
        }

        public async Task<ServiceResponse<OrderModel>> OnUpdateEntity(OrderModel entity)
        {
            OrderContext dbContext = default;
            GetClassRef.GetDbContext(ref dbContext!);

            var validOrder = await dbContext.Orders.FindAsync(entity.Id);

            if (validOrder is null) return new ServiceResponse<OrderModel>(false, null, "Nothing to update");

            validOrder.OrderDetails = entity.OrderDetails;
            validOrder.UserId = entity.UserId;
            validOrder.UpdatedDate = entity.UpdatedDate;

            dbContext.Update(validOrder);

            return new ServiceResponse<OrderModel>(true, validOrder, "Updated Order");
        }
        public async Task<ServiceResponse<OrderModel>> OnGetOrderId(Guid id)
        {
            OrderContext dbContext = default;
            GetClassRef.GetDbContext(ref dbContext!);

            var validOrder = await dbContext.Orders.FindAsync(id);

            if (validOrder is null) return new ServiceResponse<OrderModel>(false, null, "No Order Found");

            return new ServiceResponse<OrderModel>(true, validOrder, "Order Found");
        }

        public async Task<ServiceResponse<IEnumerable<OrderModel>>> OnGetAllOrder()
        {
            OrderContext dbContext = default;
            GetClassRef.GetDbContext(ref dbContext!);
            List<OrderModel> allOrder = new();
            try
            {
                allOrder = await dbContext.Orders.ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new ServiceResponse<IEnumerable<OrderModel>>(true, allOrder, "Every Order found");
        }
        #endregion

        #region Subscribe Method / Unsubscribe Method

        public static void SubscribeEvents()
        {
            if (!_instance.IsActive) return;

            _instance.OnEventSubscription();
        }

        public static void UnSubscribeEvents()
        {
            if (!_instance.IsActive) return;

            _instance.OnEventUnSubscription();
        }


        #endregion
    }
}
