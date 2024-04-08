using FastEndpoints;
using GraphiteApi.Order.BusinessLogic.Interfaces;
using GraphiteApi.Order.DataAccess.DataModels;
using GraphiteApi.Order.BusinessLogic.Extensions;

namespace GraphiteApi.Order.API.Endpoints.Order.Get.GetById
{
    public class GetOrderByIdEndPoint : Endpoint<GetOrderByIdRequest, GetOrderByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderByIdEndPoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override void Configure()
        {
            Post("/getById/{Id}");
            AllowAnonymous();
            Group<OrderApiGroup>();
        }

        public override async Task HandleAsync(GetOrderByIdRequest req, CancellationToken ct)
        {
            if (!Guid.TryParse(req.OrderId, out var guid))
            {
                await SendErrorsAsync(statusCode: 400, ct);
                return;
            }

            var response = await _unitOfWork.OrderRepository.GetByIdAsync(guid);

            if (!response.Success)
            {
                await SendErrorsAsync(statusCode: 400, ct);
                return;
            }

            await SendAsync(new() { OrderDto = (response.Data ?? new OrderModel()).ConvertToDto() }, 200, ct);
        }
    }
}
