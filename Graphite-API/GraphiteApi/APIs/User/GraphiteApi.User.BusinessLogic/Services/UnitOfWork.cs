using GraphiteApi.User.BusinessLogic.Interfaces;
using GraphiteApi.User.DataAccess.Contexts;

namespace GraphiteApi.User.BusinessLogic.Services;

public class UnitOfWork : IUnitOfWork
{
	private readonly UserContext _userCtx;

	public IUserRepository UserRepository { get; }

	public UnitOfWork(UserContext userCtx)
	{
		_userCtx = userCtx;
		UserRepository = new UserRepository(_userCtx);
	}

	public async Task SaveAsync()
	{
		await _userCtx.SaveChangesAsync();
	}

	public void Dispose()
	{
		_userCtx.Dispose();
	}
}