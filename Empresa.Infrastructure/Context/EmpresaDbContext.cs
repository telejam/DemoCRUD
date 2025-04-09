using Empresa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Infrastructure.Context
{
    public class EmpresaDbContext : DbContext
    {
        public EmpresaDbContext(DbContextOptions<EmpresaDbContext> options) : base(options) { }

        public DbSet<Movimiento> Movimientos => Set<Movimiento>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Estado> Estados => Set<Estado>();
        public DbSet<Operario> Operarios => Set<Operario>();
        public DbSet<Equipo> Equipos => Set<Equipo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimientoOperario>()
                .HasKey(mo => new { mo.MovimientoId, mo.OperarioId });

            modelBuilder.Entity<MovimientoOperario>()
                .HasOne(mo => mo.Movimiento)
                .WithMany(m => m.Operarios)
                .HasForeignKey(mo => mo.MovimientoId);

            modelBuilder.Entity<MovimientoOperario>()
                .HasOne(mo => mo.Operario)
                .WithMany(o => o.Movimientos)
                .HasForeignKey(mo => mo.OperarioId);

            modelBuilder.Entity<MovimientoEquipo>()
                .HasKey(me => new { me.MovimientoId, me.EquipoId });

            modelBuilder.Entity<MovimientoEquipo>()
                .HasOne(me => me.Movimiento)
                .WithMany(m => m.Equipos)
                .HasForeignKey(me => me.MovimientoId);

            modelBuilder.Entity<MovimientoEquipo>()
                .HasOne(me => me.Equipo)
                .WithMany(e => e.Movimientos)
                .HasForeignKey(me => me.EquipoId);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nombre = "Empresa ABC" },
                new Cliente { Id = 2, Nombre = "Juan Pérez" },
                new Cliente { Id = 3, Nombre = "Empresa Alfa" }
            );

            modelBuilder.Entity<Estado>().HasData(
                new Estado { Id = 1, Nombre = "Nuevo" },
                new Estado { Id = 2, Nombre = "Pendiente" },
                new Estado { Id = 3, Nombre = "En Progreso" },
                new Estado { Id = 4, Nombre = "Completado" },
                new Estado { Id = 5, Nombre = "Cancelado" }
            );

            modelBuilder.Entity<Operario>().HasData(
                new Operario { Id = 1, Nombre = "Mario García" },
                new Operario { Id = 2, Nombre = "Luisa Díaz" },
                new Operario { Id = 3, Nombre = "Carlos Torres" },
                new Operario { Id = 4, Nombre = "Lucía Romero" }
            );

            modelBuilder.Entity<Equipo>().HasData(
                new Equipo { Id = 1, Nombre = "Camión 1" },
                new Equipo { Id = 2, Nombre = "Excavadora A" },
                new Equipo { Id = 3, Nombre = "Camión 2" },
                new Equipo { Id = 4, Nombre = "Excavadora 3B" }
            );
        }
    }
}
