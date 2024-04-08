using FastEndpoints;

namespace GraphiteApi.Pencil.API;

public sealed class ApiGroup : Group
{
    public ApiGroup()
    {
        Configure("/api", ep => ep
            .Description(x => x
                .WithTags("API")
            ));
    }
}