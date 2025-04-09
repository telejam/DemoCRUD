using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Domain.Entities
{
    public class Operario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<MovimientoOperario> Movimientos { get; set; } = new();
    }
}
