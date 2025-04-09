using Empresa.Application.Dtos;
using Empresa.Application.Interfaces;
using Empresa.Domain.Entities;
using Empresa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly EmpresaDbContext _context;

        public ClienteService(EmpresaDbContext context)
        {
            _context = context;
        }


        public async Task<List<ClienteDto>> ObtenerTodos()
        {
            return await _context.Clientes
                .Select(c => new ClienteDto { Id = c.Id, Nombre = c.Nombre })
                .ToListAsync();
        }

        public async Task<ClienteDto?> ObtenerPorId(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return cliente is null ? null : new ClienteDto { Id = cliente.Id, Nombre = cliente.Nombre };
        }

        public async Task<int> Crear(ClienteDto dto)
        {
            var cliente = new Cliente { Nombre = dto.Nombre };
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task<bool> Actualizar(int id, ClienteDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null) return false;

            cliente.Nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
