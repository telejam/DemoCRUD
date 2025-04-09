using Empresa.Application.Dtos;

namespace Empresa.Application.Interfaces
{
    public interface IEquipoService
    {
        Task<List<EquipoDto>> ObtenerTodos();
        Task<EquipoDto?> ObtenerPorId(int id);
        Task<int> Crear(EquipoDto dto);
        Task<bool> Actualizar(int id, EquipoDto dto);
        Task<bool> Eliminar(int id);
    }
}