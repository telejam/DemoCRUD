using Empresa.Application.Dtos;

namespace Empresa.Application.Interfaces
{
    public interface IMovimientoService
    {
        Task<List<MovimientoDto>> ObtenerTodos();
        Task<MovimientoDto?> ObtenerPorId(int id);
        Task<int> Crear(MovimientoDto dto);
        Task<bool> Actualizar(int id, MovimientoDto dto);
        Task<bool> Eliminar(int id);
    }
}