using FastEndpoints;

namespace GraphiteApi.Order.API.Endpoints.Order
{
    public sealed class ApiGroup : Group
    {
        public ApiGroup()
        {
            Configure("/api", ep =>

            {
                ep.Description(x => x
                    .WithTags("API"));
            });
        }
    }
}
