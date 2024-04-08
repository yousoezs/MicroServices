using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.User.API.Endpoints.User.Get.GetAll;

public class GetAllUsersResponse
{
	public IEnumerable<UserDto> UserDtos { get; set; } = new List<UserDto>();
}