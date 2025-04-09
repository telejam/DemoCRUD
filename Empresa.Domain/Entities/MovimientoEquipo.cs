using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Domain.Entities
{
    public class MovimientoEquipo
    {
        public int MovimientoId { get; set; }
        public Movimiento Movimiento { get; set; } = null!;
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; } = null!;
    }
}
