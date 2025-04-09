using Empresa.Application.Dtos;
using System.Net.Http.Json;

namespace Empresa.Web.Services
{
    public class OperarioApiService
    {
        private const string URL = "api/operarios";
        private readonly HttpClient _http;

        public OperarioApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<OperarioDto>?> GetAll() =>
            await _http.GetFromJsonAsync<List<OperarioDto>>(URL);

        public async Task<OperarioDto?> GetById(int id) =>
            await _http.GetFromJsonAsync<OperarioDto>($"{URL}/{id}");

        public async Task<bool> Create(OperarioDto dto)
        {
            var response = await _http.PostAsJsonAsync(URL, dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, OperarioDto dto)
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
