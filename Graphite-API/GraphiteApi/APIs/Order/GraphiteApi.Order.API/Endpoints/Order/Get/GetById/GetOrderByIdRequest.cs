using FastEndpoints;

namespace GraphiteApi.Order.API.Endpoints.Order.Get.GetById
{
    public class GetOrderByIdRequest 
    {
        [FromHeader]
        public string OrderId { get; set; } = string.Empty;
    }
}
