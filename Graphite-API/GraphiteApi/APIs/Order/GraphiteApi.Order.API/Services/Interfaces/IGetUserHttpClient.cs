using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Order.API.Services.Interfaces
{
    public interface IGetUserHttpClient
    {
        Task<UserResponse?> GetUserFromUserApi(string id);
    }
}
