using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.User.API.Endpoints.User.Get.LoginUser;

public class LoginUserResponse
{
	public UserDto? UserDto { get; set; }
}