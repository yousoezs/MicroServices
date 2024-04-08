using FastEndpoints;
using GraphiteApi.Order.BusinessLogic.Interfaces;
using GraphiteApi.Order.DataAccess.DataModels;
using GraphiteApi.Order.BusinessLogic.Extensions;

namespace GraphiteApi.Order.API.Endpoints.Order.Get.GetAll
{
    public class GetAllOrderEndpoint : EndpointWithoutRequest<GetAllOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrderEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override void Configure()
        {
            Get("/getAll");
            AllowAnonymous();
            Group<OrderApiGroup>();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var response = await _unitOfWork.OrderRepository.GetAllAsync();

            if (!response.Success)
            {
                await SendErrorsAsync(statusCode: 400, ct);
                return;
            }

            await SendAsync(new() { OrderDtos = (response.Data ?? new List<OrderModel>()).Select(x => x.ConvertToDto()) }, 200, ct);
        }
    }
}
