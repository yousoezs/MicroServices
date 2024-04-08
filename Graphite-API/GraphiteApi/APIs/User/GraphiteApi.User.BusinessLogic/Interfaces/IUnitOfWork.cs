namespace GraphiteApi.User.BusinessLogic.Interfaces;

public interface IUnitOfWork : IDisposable
{
	IUserRepository UserRepository { get; }

	Task SaveAsync();
}