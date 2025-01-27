using Microsoft.AspNetCore.Mvc;
using Puerco_Boxing_Backend.Models;
using Puerco_Boxing_Backend.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly PuercoBoxingDbContext _context;

    public UsuariosController(PuercoBoxingDbContext context)
    {
        _context = context;
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] Usuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest("El usuario no puede estar vacío.");
        }

        

        // Agregar el usuario a la base de datos
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Usuario registrado exitosamente", usuario });
    }

    [HttpGet]
    public async Task<IActionResult> GetUsuarios()
    {
        return Ok(await _context.Usuarios.ToListAsync());
    }

    [HttpDelete("Eliminar/{cedula}")]
    public async Task<IActionResult> EliminarUsuarioPorCedula(string cedula)
    {
        //Limpia posibles espacios no válidos
        cedula = cedula.Trim();

        // Buscar al usuario por cédula
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Cedula == cedula);

        // Si no se encuentra el usuario, retornar un error 404
        if (usuario == null)
        {
            return NotFound(new { mensaje = "Usuario no encontrado." });
        }

        // Eliminar al usuario
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Usuario eliminado exitosamente." });
    }


    [HttpPut("Modificar/{cedula}")]
    public async Task<IActionResult> ModificarUsuarioPorCedula(string cedula, [FromBody] Usuario usuarioActualizado)
    {
        // Verificar si la cédula proporcionada coincide
        if (cedula != usuarioActualizado.Cedula)
        {
            return BadRequest(new { mensaje = "La cédula proporcionada no coincide con el usuario." });
        }

        // Buscar al usuario existente por su cédula
        var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Cedula == cedula);
        if (usuarioExistente == null)
        {
            return NotFound(new { mensaje = "Usuario no encontrado." });
        }

        // Actualizar los datos del usuario
        usuarioExistente.Nombre = usuarioActualizado.Nombre;
        usuarioExistente.Correo = usuarioActualizado.Correo;
        usuarioExistente.Contraseña = usuarioActualizado.Contraseña;
        usuarioExistente.Rol = usuarioActualizado.Rol;

        // Guardar los cambios en la base de datos
        _context.Entry(usuarioExistente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Usuario modificado exitosamente", usuario = usuarioExistente });
    }


}
