using GraphiteApi.Domain.Commons.DataTransferObjects;
using GraphiteApi.User.DataAccess.DataModels;

namespace GraphiteApi.User.BusinessLogic.Services.Extensions;

public static class UserConvertToExtensions
{
	public static UserDto ConvertToDto(this UserModel m)
	{
		return new UserDto()
		{
			Id = m.Id,
			Email = m.Email,
			Password = m.Password,
			Role = m.Role,
			CreatedDate = m.CreatedDate,
			UpdatedDate = m.UpdatedDate
		};
	}

	public static UserModel ConvertToModel(this UserDto d)
	{
		return new UserModel()
		{
			Id = d.Id,
			Email = d.Email,
			Password = d.Password,
			Role = d.Role,
			CreatedDate = d.CreatedDate,
			UpdatedDate = d.UpdatedDate
		};
	}
}