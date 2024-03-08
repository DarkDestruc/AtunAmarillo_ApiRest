using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtunAmarillo_ApiRest.Data;
using AtunAmarillo_ApiRest.Models;

namespace AtunAmarillo_ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoesController : ControllerBase
    {
        private readonly AtunAmarilloDbContext _context;

        public DetallePedidoesController(AtunAmarilloDbContext context)
        {
            _context = context;
        }

        // GET: api/DetallePedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallePedidos()
        {
          if (_context.DetallePedidos == null)
          {
              return NotFound();
          }
            return await _context.DetallePedidos.ToListAsync();
        }

        // GET: api/DetallePedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetallePedido(int id)
        {
          if (_context.DetallePedidos == null)
          {
              return NotFound();
          }
            var detallePedido = await _context.DetallePedidos.FindAsync(id);

            if (detallePedido == null)
            {
                return NotFound();
            }

            return detallePedido;
        }

        // PUT: api/DetallePedidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePedido(int id, DetallePedido detallePedido)
        {
            if (id != detallePedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

        // POST: api/DetallePedidoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedido detallePedido)
        {
          if (_context.DetallePedidos == null)
          {
              return Problem("Entity set 'AtunAmarilloDbContext.DetallePedidos'  is null.");
          }
            _context.DetallePedidos.Add(detallePedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallePedido", new { id = detallePedido.Id }, detallePedido);
        }

        // DELETE: api/DetallePedidoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            if (_context.DetallePedidos == null)
            {
                return NotFound();
            }
            var detallePedido = await _context.DetallePedidos.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            _context.DetallePedidos.Remove(detallePedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallePedidoExists(int id)
        {
            return (_context.DetallePedidos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
