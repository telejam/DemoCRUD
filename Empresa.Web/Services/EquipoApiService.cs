using Empresa.Application.Dtos;
using System.Net.Http.Json;

namespace Empresa.Web.Services
{
    public class EquipoApiService
    {
        private const string URL = "api/equipos";
        private readonly HttpClient _http;

        public EquipoApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EquipoDto>?> GetAll() =>
            await _http.GetFromJsonAsync<List<EquipoDto>>(URL);

        public async Task<EquipoDto?> GetById(int id) =>
            await _http.GetFromJsonAsync<EquipoDto>($"{URL}/{id}");

        public async Task<bool> Create(EquipoDto dto)
        {
            var response = await _http.PostAsJsonAsync(URL, dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, EquipoDto dto)
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
