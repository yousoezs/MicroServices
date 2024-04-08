
using GraphiteApi.Domain.Commons.DataTransferObjects;
using GraphiteApi.Order.API.Services.Interfaces;

namespace GraphiteApi.Order.API.Services.User
{
    public class GetUserHttpClient : IGetUserHttpClient
    {
        private HttpClient _httpClient;

        public GetUserHttpClient(HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        public async Task<UserResponse?> GetUserFromUserApi(string id)
        {
            var response = await _httpClient.GetAsync($"api/user/getbyid/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            if (response.Content.Headers.ContentLength == 0)
            {
                return null;
            }
            else
            {
                var user = await response.Content.ReadFromJsonAsync<UserResponse>();
                return user;
            }

            return null;
        }
    }
}

public class UserResponse
{
    public UserDto UserDto { get; set; }
}
