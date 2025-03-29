using SeguroAPI.Models;
using SeguroAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SeguroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AseguradosController : ControllerBase
    {
        private readonly SeguroDbContext _context;

        public AseguradosController(SeguroDbContext context)
        {
            _context = context;
        }

        // Obtener todos los asegurados con paginación
        [HttpGet]
        public async Task<IActionResult> GetAsegurados(int page = 1, int pageSize = 10)
        {
            var asegurados = await _context.Asegurados
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Ok(asegurados);
        }

        // Obtener asegurado por número de identificación
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsegurado(string id)
        {
            var asegurado = await _context.Asegurados.FindAsync(id);
            if (asegurado == null) return NotFound(new { message = "Asegurado no encontrado" });
            return Ok(asegurado);
        }

        // Crear un nuevo asegurado
        [HttpPost]
        public async Task<IActionResult> CreateAsegurado([FromBody] Asegurado asegurado)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exists = await _context.Asegurados.FindAsync(asegurado.NumeroIdentificacion);
            if (exists != null) return Conflict(new { message = "Número de Identificación ya existe" });

            _context.Asegurados.Add(asegurado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAsegurado), new { id = asegurado.NumeroIdentificacion }, asegurado);
        }

        // Actualizar asegurado
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsegurado(string id, [FromBody] Asegurado asegurado)
        {
            if (id != asegurado.NumeroIdentificacion) 
                return BadRequest(new { message = "El ID no coincide" });

            var exists = await _context.Asegurados.FindAsync(id);
            if (exists == null) return NotFound(new { message = "Asegurado no encontrado" });

            _context.Entry(exists).CurrentValues.SetValues(asegurado);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar asegurado
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsegurado(string id)
        {
            var asegurado = await _context.Asegurados.FindAsync(id);
            if (asegurado == null) return NotFound(new { message = "Asegurado no encontrado" });

            _context.Asegurados.Remove(asegurado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
