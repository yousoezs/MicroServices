using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.User.API.Endpoints.User.Post;

public class AddUserRequest
{
	public UserDto? UserDto { get; set; }
}