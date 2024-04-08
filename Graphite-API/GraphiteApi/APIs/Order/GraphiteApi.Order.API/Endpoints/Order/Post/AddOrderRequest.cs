using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Order.API.Endpoints.Order.Post
{
    public class AddOrderRequest
    {
        public OrderDto? OrderDto { get; set; }
    }
}
