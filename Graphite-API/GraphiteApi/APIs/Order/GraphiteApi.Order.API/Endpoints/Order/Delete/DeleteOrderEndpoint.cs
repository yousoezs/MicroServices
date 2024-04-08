using FastEndpoints;
using GraphiteApi.Order.BusinessLogic.Interfaces;
using GraphiteApi.Order.DataAccess.DataModels;
using GraphiteApi.Order.BusinessLogic.Extensions;

namespace GraphiteApi.Order.API.Endpoints.Order.Delete
{
    public class DeleteOrderEndpoint : Endpoint<DeleteOrderRequest, DeleteOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override void Configure()
        {
            Post("/delete/{Id}");
            AllowAnonymous();
            Group<OrderApiGroup>();
        }

        public override async Task HandleAsync(DeleteOrderRequest req, CancellationToken ct)
        {
            if (!Guid.TryParse(req.Id, out var guid))
            {
                await SendErrorsAsync(statusCode: 400, ct);
                return;
            }

            var response = await _unitOfWork.OrderRepository.DeleteAsync(guid);

            if (!response.Success)
            {
                await SendErrorsAsync(statusCode: 400, ct);
                return;
            }

            await _unitOfWork.SaveAsync();
            await SendAsync(new() { OrderDto = (response.Data ?? new OrderModel()).ConvertToDto() }, 200, ct);
        }
    }
}
