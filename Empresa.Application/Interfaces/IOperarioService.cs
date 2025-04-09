using Empresa.Application.Dtos;
using Empresa.Domain.Entities;

namespace Empresa.Application.Interfaces
{
    public interface IOperarioService
    {
        Task<List<OperarioDto>> ObtenerTodos();
        Task<OperarioDto?> ObtenerPorId(int id);
        Task<int> Crear(OperarioDto dto);
        Task<bool> Actualizar(int id, OperarioDto dto);
        Task<bool> Eliminar(int id);
    }
}