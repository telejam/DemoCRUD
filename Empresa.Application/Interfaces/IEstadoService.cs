using Empresa.Application.Dtos;

namespace Empresa.Application.Interfaces
{
    public interface IEstadoService
    {
        Task<List<EstadoDto>> ObtenerTodos();
        Task<EstadoDto?> ObtenerPorId(int id);
        Task<int> Crear(EstadoDto dto);
        Task<bool> Actualizar(int id, EstadoDto dto);
        Task<bool> Eliminar(int id);
    }
}