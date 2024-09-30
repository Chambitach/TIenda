using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TIenda.Models;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly TiendaContext _context;

    public UsuariosController(TiendaContext context)
    {
        _context = context;
    }

    // GET: api/Usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        try
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            // Log the exception (ex) as needed
            return StatusCode(500, "Error al obtener los usuarios.");
        }
    }

    // GET: api/Usuarios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        try
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            // Log the exception (ex) as needed
            return StatusCode(500, "Error al obtener el usuario.");
        }
    }

    // POST: api/Usuarios
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdUsuario }, usuario);
        }
        catch (Exception ex)
        {
            // Log the exception (ex) as needed
            return StatusCode(500, "Error al crear el usuario.");
        }
    }

    // PUT: api/Usuarios/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.IdUsuario)
        {
            return BadRequest("El ID del usuario no coincide.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
            {
                return NotFound("Usuario no encontrado.");
            }
            else
            {
                throw;
            }
        }
        catch (Exception ex)
        {
            // Log the exception (ex) as needed
            return StatusCode(500, "Error al actualizar el usuario.");
        }
    }


    // DELETE: api/Usuarios/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        try
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            // Log the exception (ex) as needed
            return StatusCode(500, "Error al eliminar el usuario.");
        }
    }



    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.IdUsuario == id);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == loginRequest.Email && u.Contraseña == loginRequest.Contraseña);

        if (usuario == null)
        {
            return Unauthorized("Credenciales inválidas.");
        }

        // Puedes devolver datos adicionales si lo necesitas, como un token JWT
        return Ok(usuario);
    }

    // Definir la clase LoginRequest dentro del controlador
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }

}
