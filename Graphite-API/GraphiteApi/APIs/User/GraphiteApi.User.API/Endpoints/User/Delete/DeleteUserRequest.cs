using FastEndpoints;

namespace GraphiteApi.User.API.Endpoints.User.Delete;

public class DeleteUserRequest
{
	public string Id { get; set; } = string.Empty;
}