using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.User.API.Endpoints.User.Get.GetById;

public class GetUserByIdResponse
{
	public UserDto? UserDto { get; set; }
}