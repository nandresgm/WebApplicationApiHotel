using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Data;
using WebApplicationApiHotel.Models.TipoHabitacion;

namespace WebApplicationApiHotel.Controllers.TipoHabitaciones
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoHabitacionsController : ControllerBase
    {
        private readonly WebApplicationApiHotelContextTipoHabitacion _context;

        public TipoHabitacionsController(WebApplicationApiHotelContextTipoHabitacion context)
        {
            _context = context;
        }

        // GET: api/TipoHabitacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoHabitacion>>> GetTipoHabitacion()
        {
          if (_context.TipoHabitacion == null)
          {
              return NotFound();
          }
            return await _context.TipoHabitacion.ToListAsync();
        }

        // GET: api/TipoHabitacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoHabitacion>> GetTipoHabitacion(int id)
        {
          if (_context.TipoHabitacion == null)
          {
              return NotFound();
          }
            var tipoHabitacion = await _context.TipoHabitacion.FindAsync(id);

            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return tipoHabitacion;
        }

        // PUT: api/TipoHabitacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoHabitacion(int id, TipoHabitacion tipoHabitacion)
        {
            if (id != tipoHabitacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoHabitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoHabitacionExists(id))
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

        // POST: api/TipoHabitacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoHabitacion>> PostTipoHabitacion(TipoHabitacion tipoHabitacion)
        {
          if (_context.TipoHabitacion == null)
          {
              return Problem("Entity set 'WebApplicationApiHotelContextTipoHabitacion.TipoHabitacion'  is null.");
          }
            _context.TipoHabitacion.Add(tipoHabitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoHabitacion", new { id = tipoHabitacion.Id }, tipoHabitacion);
        }

        // DELETE: api/TipoHabitacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoHabitacion(int id)
        {
            if (_context.TipoHabitacion == null)
            {
                return NotFound();
            }
            var tipoHabitacion = await _context.TipoHabitacion.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            _context.TipoHabitacion.Remove(tipoHabitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoHabitacionExists(int id)
        {
            return (_context.TipoHabitacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
