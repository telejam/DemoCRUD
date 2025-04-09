using Empresa.Application.Dtos;

namespace Empresa.Application.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> ObtenerTodos();
        Task<ClienteDto?> ObtenerPorId(int id);
        Task<int> Crear(ClienteDto dto);
        Task<bool> Actualizar(int id, ClienteDto dto);
        Task<bool> Eliminar(int id);
    }
}