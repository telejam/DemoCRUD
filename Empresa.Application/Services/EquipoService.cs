using Empresa.Application.Dtos;
using Empresa.Application.Interfaces;
using Empresa.Domain.Entities;
using Empresa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Application.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly EmpresaDbContext _context;

        public EquipoService(EmpresaDbContext context)
        {
            _context = context;
        }


        public async Task<List<EquipoDto>> ObtenerTodos()
        {
            return await _context.Equipos
                .Select(c => new EquipoDto { Id = c.Id, Nombre = c.Nombre })
                .ToListAsync();
        }

        public async Task<EquipoDto?> ObtenerPorId(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            return equipo is null ? null : new EquipoDto { Id = equipo.Id, Nombre = equipo.Nombre };
        }

        public async Task<int> Crear(EquipoDto dto)
        {
            var equipo = new Equipo { Nombre = dto.Nombre };
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return equipo.Id;
        }

        public async Task<bool> Actualizar(int id, EquipoDto dto)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo is null) return false;

            equipo.Nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo is null) return false;

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
