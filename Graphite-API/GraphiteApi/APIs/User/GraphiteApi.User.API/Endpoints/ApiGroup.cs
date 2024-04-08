using FastEndpoints;

namespace GraphiteApi.User.API.Endpoints;

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