using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Order.API.Endpoints.Order.Get.GetAll
{
    public class GetAllOrderResponse
    {
        public IEnumerable<OrderDto> OrderDtos { get; set; } = new List<OrderDto>();
    }
}
