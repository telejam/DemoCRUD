using Empresa.Application.Dtos;
using Empresa.Application.Interfaces;
using Empresa.Domain.Entities;
using Empresa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Application.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly EmpresaDbContext _context;

        public EstadoService(EmpresaDbContext context)
        {
            _context = context;
        }


        public async Task<List<EstadoDto>> ObtenerTodos()
        {
            return await _context.Estados
                .Select(c => new EstadoDto { Id = c.Id, Nombre = c.Nombre })
                .ToListAsync();
        }

        public async Task<EstadoDto?> ObtenerPorId(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            return estado is null ? null : new EstadoDto { Id = estado.Id, Nombre = estado.Nombre };
        }

        public async Task<int> Crear(EstadoDto dto)
        {
            var estado = new Estado { Nombre = dto.Nombre };
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();
            return estado.Id;
        }

        public async Task<bool> Actualizar(int id, EstadoDto dto)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado is null) return false;

            estado.Nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado is null) return false;

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
