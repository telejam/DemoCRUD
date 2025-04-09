using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Domain.Entities
{
    public class MovimientoOperario
    {
        public int MovimientoId { get; set; }
        public Movimiento Movimiento { get; set; } = null!;
        public int OperarioId { get; set; }
        public Operario Operario { get; set; } = null!;
    }
}
