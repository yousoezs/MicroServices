using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Order.API.Endpoints.Order.Put
{
    public class UpdateOrderRequest
    {
        public OrderDto? OrderDto { get; set; }
    }
}
