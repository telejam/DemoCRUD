using Empresa.Application.Dtos;
using Empresa.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoService _service;

        public MovimientosController(IMovimientoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _service.ObtenerTodos());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.ObtenerPorId(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimientoDto dto)
        {
            var id = await _service.Crear(dto);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MovimientoDto dto)
        {
            var updated = await _service.Actualizar(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Eliminar(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
