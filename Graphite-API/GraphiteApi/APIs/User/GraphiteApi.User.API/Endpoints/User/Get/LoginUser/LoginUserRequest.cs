using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.User.API.Endpoints.User.Get.LoginUser;

public class LoginUserRequest
{
	public UserDto? UserDto { get; set; }
}