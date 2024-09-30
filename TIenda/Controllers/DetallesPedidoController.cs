using Microsoft.AspNetCore.Mvc;
using TIenda.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TIenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidoController : ControllerBase
    {
        private readonly TiendaContext _context;

        public DetallesPedidoController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/DetallesPedido
        [HttpGet]
        public ActionResult<IEnumerable<DetallePedido>> GetDetallesPedido()
        {
            return _context.DetallesPedido.ToList();
        }

        // GET: api/DetallesPedido/5
        [HttpGet("{id}")]
        public ActionResult<DetallePedido> GetDetallePedido(int id)
        {
            var detallePedido = _context.DetallesPedido.Find(id);

            if (detallePedido == null)
            {
                return NotFound();
            }

            return detallePedido;
        }

        // POST: api/DetallesPedido
        [HttpPost]
        public IActionResult PostDetallePedido(DetallePedido detallePedido)
        {
            // No asignes un valor a detallePedido.IdDetalle aquí
            _context.DetallesPedido.Add(detallePedido);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDetallePedido), new { id = detallePedido.IdDetalle }, detallePedido);
        }


        // PUT: api/DetallesPedido/5
        [HttpPut("{id}")]
        public IActionResult PutDetallePedido(int id, DetallePedido detallePedido)
        {
            if (id != detallePedido.IdDetalle)
            {
                return BadRequest();
            }

            _context.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/DetallesPedido/5
        [HttpDelete("{id}")]
        public ActionResult<DetallePedido> DeleteDetallePedido(int id)
        {
            var detallePedido = _context.DetallesPedido.Find(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            _context.DetallesPedido.Remove(detallePedido);
            _context.SaveChanges();

            return detallePedido;
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallesPedido.Any(e => e.IdDetalle == id);
        }
    }
}
