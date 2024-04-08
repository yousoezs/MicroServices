using GraphiteApi.Domain.Commons.Services;
using GraphiteApi.User.BusinessLogic.Interfaces;
using GraphiteApi.User.DataAccess.Contexts;
using GraphiteApi.User.DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;

namespace GraphiteApi.User.BusinessLogic.Services;

public class UserRepository : IUserRepository
{
	private readonly UserContext _userCtx;

	public UserRepository(UserContext userCtx)
	{
		_userCtx = userCtx;
	}

	public async Task<ServiceResponse<UserModel>> GetByIdAsync(Guid id)
	{
		var userModel = await _userCtx.User.FindAsync(id);

		if (userModel is null)
			return new ServiceResponse<UserModel>(false, null, "");

		return new ServiceResponse<UserModel>(true, userModel, "");
	}

	public async Task<ServiceResponse<IEnumerable<UserModel>>> GetAllAsync()
	{
		var userModels = await _userCtx.User.ToListAsync();
		return new ServiceResponse<IEnumerable<UserModel>>(true, userModels, "");
	}

	public async Task<ServiceResponse<UserModel>> AddAsync(UserModel entity)
	{
		entity.CreatedDate = DateTime.UtcNow;
		entity.UpdatedDate = DateTime.UtcNow;

		await _userCtx.User.AddAsync(entity);

		return new ServiceResponse<UserModel>(true, entity, "");
	}

	public async Task<ServiceResponse<UserModel>> UpdateAsync(UserModel entity)
	{
		var toUpdate = await _userCtx.User.FindAsync(entity.Id);

		if (toUpdate is null)
			return new ServiceResponse<UserModel>(false, null, "");

		toUpdate.Email = entity.Email;
		toUpdate.Password = entity.Password;
		toUpdate.UpdatedDate = DateTime.UtcNow;
		toUpdate.Role = entity.Role;

		_userCtx.User.Update(toUpdate);

		return new ServiceResponse<UserModel>(true, toUpdate, "");
	}

	public async Task<ServiceResponse<UserModel>> DeleteAsync(Guid id)
	{
		var userModel = await _userCtx.User.FindAsync(id);

		if (userModel is null)
			return new ServiceResponse<UserModel>(false, null, "");

		_userCtx.User.Remove(userModel);
		return new ServiceResponse<UserModel>(true, userModel, "");
	}

	public async Task<ServiceResponse<UserModel>> LoginAsync(UserModel entity)
	{
		var userModel = await _userCtx.User
			.FirstOrDefaultAsync(x =>
				x.Email.ToLower().Equals(entity.Email.ToLower()) &&
				x.Password.Equals(entity.Password));

		if (userModel is null)
			return new ServiceResponse<UserModel>(false, null, "");

		return new ServiceResponse<UserModel>(true, userModel, "");
	}
}