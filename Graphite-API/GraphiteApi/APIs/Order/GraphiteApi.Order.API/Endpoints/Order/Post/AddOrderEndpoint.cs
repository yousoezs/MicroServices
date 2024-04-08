using FastEndpoints;
using GraphiteApi.Order.API.Services.Interfaces;
using GraphiteApi.Order.API.Services.User;
using GraphiteApi.Order.BusinessLogic.Extensions;
using GraphiteApi.Order.BusinessLogic.Interfaces;
using GraphiteApi.Order.DataAccess.DataModels;

namespace GraphiteApi.Order.API.Endpoints.Order.Post
{
    public class AddOrderEndpoint : Endpoint<AddOrderRequest, AddOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        private IGetPencilHttpClient _getPencilId;
        private IGetUserHttpClient _getUserId;
        private IHttpClientFactory _factoryClient;

        public AddOrderEndpoint(IUnitOfWork unitOfWork, IHttpClientFactory factory)
        {
            _unitOfWork = unitOfWork;
            _factoryClient = factory;
        }

        public override void Configure()
        {
            Post("/add");
            AllowAnonymous();
            Group<OrderApiGroup>();
        }

        public override async Task HandleAsync(AddOrderRequest req, CancellationToken ct)
        {
            var userClient = _factoryClient.CreateClient("graphiteapi.user.api");
            userClient.BaseAddress = new Uri("http://graphiteapi.user.api:8080");
            _getUserId = new GetUserHttpClient(userClient);
            var user = await _getUserId.GetUserFromUserApi(req.OrderDto.UserId.Id.ToString());

            var pencilClient = _factoryClient.CreateClient("graphiteapi.pencil.api");
            pencilClient.BaseAddress = new Uri("http://graphiteapi.pencil.api:8080");
            _getPencilId = new GetPencilHttpClient(pencilClient);
            var id = req.OrderDto.OrderDetails[0].Product.Id;
            var pencil = await _getPencilId.GetPencilFromApi(id);


            if (user is null)
            {
                await SendErrorsAsync(statusCode: 400, cancellation: ct);
                return;
            }
            if (req.OrderDto is null)
            {
                await SendErrorsAsync(statusCode: 400, cancellation: ct);
                return;
            }

            req.OrderDto.UserId = user.UserDto;

            var response = await _unitOfWork.OrderRepository.AddAsync(req.OrderDto.ConvertToModel());

            if (!response.Success)
            {
                await SendErrorsAsync(statusCode: 400, cancellation: ct);
                return;
            }
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            await SendAsync(new() { OrderDto = (response.Data ?? new OrderModel()).ConvertToDto() }, 200, ct);
        }
    }
}
