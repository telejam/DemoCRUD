using Empresa.Application.Dtos;
using System.Net.Http.Json;

namespace Empresa.Web.Services
{
    public class ClienteApiService
    {
        private const string URL = "api/clientes";
        private readonly HttpClient _http;

        public ClienteApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ClienteDto>?> GetAll() =>
            await _http.GetFromJsonAsync<List<ClienteDto>>(URL);

        public async Task<ClienteDto?> GetById(int id) =>
            await _http.GetFromJsonAsync<ClienteDto>($"{URL}/{id}");

        public async Task<bool> Create(ClienteDto dto)
        {
            var response = await _http.PostAsJsonAsync(URL, dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, ClienteDto dto)
        {
            var response = await _http.PutAsJsonAsync($"{URL}/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"{URL}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
