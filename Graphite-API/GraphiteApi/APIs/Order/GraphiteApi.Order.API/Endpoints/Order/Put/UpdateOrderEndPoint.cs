using FastEndpoints;
using GraphiteApi.Order.BusinessLogic.Interfaces;
using GraphiteApi.Order.BusinessLogic.Extensions;
using GraphiteApi.Order.DataAccess.DataModels;
using GraphiteApi.Order.API.Services.Interfaces;
using GraphiteApi.Domain.Commons.DataTransferObjects;
using GraphiteApi.Order.API.Services.User;

namespace GraphiteApi.Order.API.Endpoints.Order.Put
{
    public class UpdateOrderEndPoint : Endpoint<UpdateOrderRequest, UpdateOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        private IGetPencilHttpClient _getPencilClient;
        private IGetUserHttpClient _getUserClient;
        private IHttpClientFactory _factoryClient;

        public UpdateOrderEndPoint(IUnitOfWork unitOfWork, IHttpClientFactory factory)
        {
            _unitOfWork = unitOfWork;
            _factoryClient = factory;
        }

        public override void Configure()
        {
            Post("/update");
            AllowAnonymous();
            Group<OrderApiGroup>();
        }

        public override async Task HandleAsync(UpdateOrderRequest req, CancellationToken ct)
        {
            PencilDto? pencil = default;
            var client = _factoryClient.CreateClient("graphiteapi.supergateway");

            _getUserClient = new GetUserHttpClient(client);
            var user = await _getUserClient.GetUserFromUserApi(req.OrderDto.UserId.Id.ToString());

            if (req.OrderDto is null)
            {
                await SendErrorsAsync(statusCode: 400, cancellation: ct);
                return;
            }
            req.OrderDto.UserId = user.UserDto;
            var response = await _unitOfWork.OrderRepository.UpdateAsync(req.OrderDto.ConvertToModel());

            if (!response.Success)
            {
                await SendErrorsAsync(statusCode: 400, cancellation: ct);
                return;
            }

            await _unitOfWork.SaveAsync();
            await SendAsync(new() { OrderDto = (response.Data ?? new OrderModel()).ConvertToDto() }, 200, ct);
        }
    }
}
