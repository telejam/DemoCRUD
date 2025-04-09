using Empresa.Application.Dtos;
using System.Net.Http.Json;

namespace Empresa.Web.Services
{
    public class MovimientoApiService
    {
        private const string URL = "api/movimientos";
        private readonly HttpClient _http;

        public MovimientoApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MovimientoDto>?> GetAll()
            => await _http.GetFromJsonAsync<List<MovimientoDto>>(URL);

        public async Task<MovimientoDto?> GetById(int id)
            => await _http.GetFromJsonAsync<MovimientoDto>($"{URL}/{id}");

        public async Task<int?> Create(MovimientoDto dto)
        {
            var response = await _http.PostAsJsonAsync(URL, dto);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : null;
        }

        public async Task<bool> Update(int id, MovimientoDto dto)
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
