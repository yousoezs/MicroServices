using FastEndpoints;
using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Order.API.Endpoints.Order.Delete
{
    public class DeleteOrderRequest
    {
        [FromHeader]
        public string Id { get; set; } = string.Empty;
    }
}
