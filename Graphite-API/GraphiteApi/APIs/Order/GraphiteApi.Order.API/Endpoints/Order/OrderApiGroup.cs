using FastEndpoints;

namespace GraphiteApi.Order.API.Endpoints.Order
{
    public sealed class OrderApiGroup : SubGroup<ApiGroup>
    {
        public OrderApiGroup() 
        {
            Configure("/order", ep =>
            {
                ep.Description(x => x
                    .WithTags("Order"));
            });
        }
    }
}
