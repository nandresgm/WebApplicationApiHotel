using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Data;
using WebApplicationApiHotel.Models.DetalleReserva;

namespace WebApplicationApiHotel.Controllers.DetalleReservas
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetalleReservasController : ControllerBase
    {
        private readonly WebApplicationApiHotelContextDetalleReservas _context;

        public DetalleReservasController(WebApplicationApiHotelContextDetalleReservas context)
        {
            _context = context;
        }

        // GET: api/DetalleReservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleReserva>>> GetDetalleReservas()
        {
          if (_context.DetalleReserva == null)
          {
              return NotFound();
          }
            return await _context.DetalleReserva.ToListAsync();
        }

        // GET: api/DetalleReservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleReserva>> GetDetalleReservas(int id)
        {
          if (_context.DetalleReserva == null)
          {
              return NotFound();
          }
            var detalleReservas = await _context.DetalleReserva.FindAsync(id);

            if (detalleReservas == null)
            {
                return NotFound();
            }

            return detalleReservas;
        }

        // PUT: api/DetalleReservas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleReservas(int id, DetalleReserva detalleReservas)
        {
            if (id != detalleReservas.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleReservas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleReservasExists(id))
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

        // POST: api/DetalleReservas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleReserva>> PostDetalleReservas(DetalleReserva detalleReservas)
        {
          if (_context.DetalleReserva == null)
          {
              return Problem("Entity set 'WebApplicationApiHotelContextDetalleReservas.DetalleReservas'  is null.");
          }
            _context.DetalleReserva.Add(detalleReservas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleReservas", new { id = detalleReservas.Id }, detalleReservas);
        }

        // DELETE: api/DetalleReservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleReservas(int id)
        {
            if (_context.DetalleReserva == null)
            {
                return NotFound();
            }
            var detalleReservas = await _context.DetalleReserva.FindAsync(id);
            if (detalleReservas == null)
            {
                return NotFound();
            }

            _context.DetalleReserva.Remove(detalleReservas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleReservasExists(int id)
        {
            return (_context.DetalleReserva?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
