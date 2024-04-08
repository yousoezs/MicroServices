using GraphiteApi.Domain.Commons.Interfaces;
using GraphiteApi.Domain.Commons.Services;
using GraphiteApi.User.DataAccess.DataModels;

namespace GraphiteApi.User.BusinessLogic.Interfaces;

public interface IUserRepository : IGenericRepository<UserModel, Guid>
{
	Task<ServiceResponse<UserModel>> LoginAsync(UserModel entity);
}