using FastEndpoints;

namespace GraphiteApi.User.API.Endpoints.User;

public sealed class UserApiGroup : SubGroup<ApiGroup>
{
	public UserApiGroup()
	{
		Configure("/user", ep =>
		{
			ep.Description(x => x
				.WithTags("User"));
		});
	}
}