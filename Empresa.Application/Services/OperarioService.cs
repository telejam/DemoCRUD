using Empresa.Application.Dtos;
using Empresa.Application.Interfaces;
using Empresa.Domain.Entities;
using Empresa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Application.Services
{
    public class OperarioService : IOperarioService
    {
        private readonly EmpresaDbContext _context;

        public OperarioService(EmpresaDbContext context)
        {
            _context = context;
        }


        public async Task<List<OperarioDto>> ObtenerTodos()
        {
            return await _context.Operarios
                .Select(c => new OperarioDto { Id = c.Id, Nombre = c.Nombre })
                .ToListAsync();
        }

        public async Task<OperarioDto?> ObtenerPorId(int id)
        {
            var operario = await _context.Operarios.FindAsync(id);
            return operario is null ? null : new OperarioDto { Id = operario.Id, Nombre = operario.Nombre };
        }

        public async Task<int> Crear(OperarioDto dto)
        {
            var operario = new Operario { Nombre = dto.Nombre };
            _context.Operarios.Add(operario);
            await _context.SaveChangesAsync();
            return operario.Id;
        }

        public async Task<bool> Actualizar(int id, OperarioDto dto)
        {
            var operario = await _context.Operarios.FindAsync(id);
            if (operario is null) return false;

            operario.Nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var operario = await _context.Operarios.FindAsync(id);
            if (operario is null) return false;

            _context.Operarios.Remove(operario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
