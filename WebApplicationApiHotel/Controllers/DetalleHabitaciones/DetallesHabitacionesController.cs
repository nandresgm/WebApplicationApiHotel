using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Data;
using WebApplicationApiHotel.Models.DetalleHabitacion;

namespace WebApplicationApiHotel.Controllers.DetalleHabitaciones
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetallesHabitacionesController : ControllerBase
    {
        private readonly WebApplicationApiHotelContextDetalleHabitaciones _context;

        public DetallesHabitacionesController(WebApplicationApiHotelContextDetalleHabitaciones context)
        {
            _context = context;
        }

        // GET: api/DetallesHabitaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.DetalleHabitacion.DetalleHabitacion>>> GetDetalleaHabitaciones()
        {
          if (_context.DetalleHabitacion == null)
          {
              return NotFound();
          }
            return await _context.DetalleHabitacion.ToListAsync();
        }

        // GET: api/DetallesHabitaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.DetalleHabitacion.DetalleHabitacion>> GetDetalleaHabitaciones(int id)
        {
          if (_context.DetalleHabitacion == null)
          {
              return NotFound();
          }
            var detalleaHabitaciones = await _context.DetalleHabitacion.FindAsync(id);

            if (detalleaHabitaciones == null)
            {
                return NotFound();
            }

            return detalleaHabitaciones;
        }

        // PUT: api/DetallesHabitaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleaHabitaciones(int id, Models.DetalleHabitacion.DetalleHabitacion detalleaHabitaciones)
        {
            if (id != detalleaHabitaciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleaHabitaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleaHabitacionesExists(id))
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

        // POST: api/DetallesHabitaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.DetalleHabitacion.DetalleHabitacion>> PostDetalleaHabitaciones(Models.DetalleHabitacion.DetalleHabitacion detalleaHabitaciones)
        {
          if (_context.DetalleHabitacion == null)
          {
              return Problem("Entity set 'WebApplicationApiHotelContextDetalleHabitaciones.DetalleaHabitaciones'  is null.");
          }
            _context.DetalleHabitacion.Add(detalleaHabitaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleaHabitaciones", new { id = detalleaHabitaciones.Id }, detalleaHabitaciones);
        }

        // DELETE: api/DetallesHabitaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleaHabitaciones(int id)
        {
            if (_context.DetalleHabitacion == null)
            {
                return NotFound();
            }
            var detalleaHabitaciones = await _context.DetalleHabitacion.FindAsync(id);
            if (detalleaHabitaciones == null)
            {
                return NotFound();
            }

            _context.DetalleHabitacion.Remove(detalleaHabitaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleaHabitacionesExists(int id)
        {
            return (_context.DetalleHabitacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
