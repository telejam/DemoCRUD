namespace Empresa.Application.Dtos
{
    public class MovimientoDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Today;
        public string Asunto { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;

        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; } = string.Empty;

        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; } = string.Empty;

        public List<int> OperarioIds { get; set; } = [];
        public List<int> EquipoIds { get; set; } = [];

        public int CantOperarios => OperarioIds?.Count ?? 0;
        public int CantEquipos => EquipoIds?.Count ?? 0;
    }
}
