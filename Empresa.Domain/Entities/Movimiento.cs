using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Domain.Entities
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Asunto { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int EstadoId { get; set; }
        public Estado Estado { get; set; } = null!;

        public List<MovimientoOperario> Operarios { get; set; } = [];
        public List<MovimientoEquipo> Equipos { get; set; } = [];
    }
}
