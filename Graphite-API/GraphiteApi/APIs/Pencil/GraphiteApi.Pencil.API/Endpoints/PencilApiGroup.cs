using FastEndpoints;

namespace GraphiteApi.Pencil.API.Endpoints;

public class PencilApiGroup : SubGroup<ApiGroup>
{
    public PencilApiGroup()
    {
        Configure("/pencil", ep =>
        {
            ep.Description(x => x.WithTags("Pencil"));
        });
    }
}