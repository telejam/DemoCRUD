using Empresa.Application.Dtos;
using System.Net.Http.Json;

namespace Empresa.Web.Services
{
    public class EstadoApiService
    {
        private const string URL = "api/estados";
        private readonly HttpClient _http;

        public EstadoApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EstadoDto>?> GetAll() =>
            await _http.GetFromJsonAsync<List<EstadoDto>>(URL);

        public async Task<EstadoDto?> GetById(int id) =>
            await _http.GetFromJsonAsync<EstadoDto>($"{URL}/{id}");

        public async Task<bool> Create(EstadoDto dto)
        {
            var response = await _http.PostAsJsonAsync(URL, dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, EstadoDto dto)
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
