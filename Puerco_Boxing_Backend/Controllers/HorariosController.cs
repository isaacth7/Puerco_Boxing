using Microsoft.AspNetCore.Mvc;
using Puerco_Boxing_Backend.Models;
using Puerco_Boxing_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Puerco_Boxing_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosController : ControllerBase
    {
        private readonly PuercoBoxingDbContext _context;

        public HorariosController(PuercoBoxingDbContext context)
        {
            _context = context;
        }

        // Generar horarios automáticamente
        [HttpPost("GenerarHorarios")]
        public async Task<IActionResult> GenerarHorarios()
        {
            var horarios = new List<Horario>();

            for (var hora = new TimeSpan(7, 0, 0); hora < new TimeSpan(22, 0, 0); hora = hora.Add(TimeSpan.FromHours(1)))
            {
                horarios.Add(new Horario
                {
                    HoraInicio = hora,
                    HoraFin = hora.Add(TimeSpan.FromHours(1)),
                    Disponible = true
                });
            }

            _context.Horarios.AddRange(horarios);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Horarios generados exitosamente", horarios });
        }

        // Obtener todos los horarios
        [HttpGet]
        public async Task<IActionResult> GetHorarios()
        {
            return Ok(await _context.Horarios.ToListAsync());
        }

        // Actualizar disponibilidad de un horario
        [HttpPut("ActualizarDisponibilidad/{id}")]
        public async Task<IActionResult> ActualizarDisponibilidad(int id, [FromBody] bool disponible)
        {
            var horario = await _context.Horarios.FindAsync(id);

            if (horario == null)
            {
                return NotFound(new { mensaje = "Horario no encontrado." });
            }

            horario.Disponible = disponible;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Disponibilidad actualizada exitosamente", horario });
        }
    }

}
