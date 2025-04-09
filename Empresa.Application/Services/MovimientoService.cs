using Empresa.Application.Dtos;
using Empresa.Application.Interfaces;
using Empresa.Domain.Entities;
using Empresa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Application.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly EmpresaDbContext _context;

        public MovimientoService(EmpresaDbContext context)
        {
            _context = context;
        }


        public async Task<List<MovimientoDto>> ObtenerTodos()
        {
            return await _context.Movimientos
                .Include(m => m.Cliente)
                .Include(m => m.Estado)
                .Include(m => m.Operarios)
                .Include(m => m.Equipos)
                .Select(m => new MovimientoDto
                {
                    Id = m.Id,
                    Fecha = m.Fecha,
                    Asunto = m.Asunto,
                    Ubicacion = m.Ubicacion,
                    ClienteId = m.ClienteId,
                    ClienteNombre = m.Cliente.Nombre,
                    EstadoId = m.EstadoId,
                    EstadoNombre = m.Estado.Nombre,
                    OperarioIds = m.Operarios.Select(o => o.OperarioId).ToList(),
                    EquipoIds = m.Equipos.Select(e => e.EquipoId).ToList()
                }).ToListAsync();
        }

        public async Task<MovimientoDto?> ObtenerPorId(int id)
        {
            var m = await _context.Movimientos
                .Include(m => m.Operarios)
                .Include(m => m.Equipos)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (m is null) return null;

            return new MovimientoDto
            {
                Id = m.Id,
                Fecha = m.Fecha,
                Asunto = m.Asunto,
                Ubicacion = m.Ubicacion,
                ClienteId = m.ClienteId,
                EstadoId = m.EstadoId,
                OperarioIds = m.Operarios.Select(o => o.OperarioId).ToList(),
                EquipoIds = m.Equipos.Select(e => e.EquipoId).ToList()
            };
        }

        public async Task<int> Crear(MovimientoDto dto)
        {
            var movimiento = new Movimiento
            {
                Fecha = dto.Fecha,
                Asunto = dto.Asunto,
                Ubicacion = dto.Ubicacion,
                ClienteId = dto.ClienteId,
                EstadoId = dto.EstadoId,
                Operarios = dto.OperarioIds.Select(id => new MovimientoOperario { OperarioId = id }).ToList(),
                Equipos = dto.EquipoIds.Select(id => new MovimientoEquipo { EquipoId = id }).ToList()
            };

            _context.Movimientos.Add(movimiento);
            await _context.SaveChangesAsync();
            return movimiento.Id;
        }

        public async Task<bool> Actualizar(int id, MovimientoDto dto)
        {
            var movimiento = await _context.Movimientos
                .Include(m => m.Operarios)
                .Include(m => m.Equipos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movimiento is null) return false;

            movimiento.Fecha = dto.Fecha;
            movimiento.Asunto = dto.Asunto;
            movimiento.Ubicacion = dto.Ubicacion;
            movimiento.ClienteId = dto.ClienteId;
            movimiento.EstadoId = dto.EstadoId;

            movimiento.Operarios = dto.OperarioIds.Select(id => new MovimientoOperario { MovimientoId = id, OperarioId = id }).ToList();
            movimiento.Equipos = dto.EquipoIds.Select(id => new MovimientoEquipo { MovimientoId = id, EquipoId = id }).ToList();

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento is null) return false;

            _context.Movimientos.Remove(movimiento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
