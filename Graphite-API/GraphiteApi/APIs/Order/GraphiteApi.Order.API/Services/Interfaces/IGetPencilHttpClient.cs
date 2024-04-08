using GraphiteApi.Domain.Commons.DataTransferObjects;
using GraphiteApi.Order.API.Services.User;

namespace GraphiteApi.Order.API.Services.Interfaces
{
    public interface IGetPencilHttpClient
    {
        Task<PencilResponse?> GetPencilFromApi(string id);
    }
}
