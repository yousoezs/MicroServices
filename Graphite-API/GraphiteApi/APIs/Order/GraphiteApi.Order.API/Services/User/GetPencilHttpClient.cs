using GraphiteApi.Domain.Commons.DataTransferObjects;
using GraphiteApi.Order.API.Services.Interfaces;

namespace GraphiteApi.Order.API.Services.User
{
    public class GetPencilHttpClient : IGetPencilHttpClient
    {
        private HttpClient _httpClient;

        public GetPencilHttpClient(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<PencilResponse?> GetPencilFromApi(string id)
        {
            var response = await _httpClient.GetAsync($"api/pencil/get/{id}");

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
                var pencil = await response.Content.ReadFromJsonAsync<PencilResponse>();
                return pencil;
            }
        }
    }

    public class PencilResponse
    {
        public PencilDto PencilDto { get; set; }
    }
}
