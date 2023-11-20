using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Data;
using WebApplicationApiHotel.Models.ComboHabitacion;

namespace WebApplicationApiHotel.Controllers.ComboHabitaciones
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ComboHabitacionsController : ControllerBase
    {
        private readonly WebApplicationApiHotelContextCombohabitacion _context;

        public ComboHabitacionsController(WebApplicationApiHotelContextCombohabitacion context)
        {
            _context = context;
        }

        // GET: api/ComboHabitacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboHabitacion>>> GetComboHabitacion()
        {
          if (_context.ComboHabitacion == null)
          {
              return NotFound();
          }
            return await _context.ComboHabitacion.ToListAsync();
        }

        // GET: api/ComboHabitacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComboHabitacion>> GetComboHabitacion(int id)
        {
          if (_context.ComboHabitacion == null)
          {
              return NotFound();
          }
            var comboHabitacion = await _context.ComboHabitacion.FindAsync(id);

            if (comboHabitacion == null)
            {
                return NotFound();
            }

            return comboHabitacion;
        }

        // PUT: api/ComboHabitacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComboHabitacion(int id, ComboHabitacion comboHabitacion)
        {
            if (id != comboHabitacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(comboHabitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComboHabitacionExists(id))
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

        // POST: api/ComboHabitacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComboHabitacion>> PostComboHabitacion(ComboHabitacion comboHabitacion)
        {
          if (_context.ComboHabitacion == null)
          {
              return Problem("Entity set 'WebApplicationApiHotelContextCombohabitacion.ComboHabitacion'  is null.");
          }
            _context.ComboHabitacion.Add(comboHabitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComboHabitacion", new { id = comboHabitacion.Id }, comboHabitacion);
        }

        // DELETE: api/ComboHabitacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComboHabitacion(int id)
        {
            if (_context.ComboHabitacion == null)
            {
                return NotFound();
            }
            var comboHabitacion = await _context.ComboHabitacion.FindAsync(id);
            if (comboHabitacion == null)
            {
                return NotFound();
            }

            _context.ComboHabitacion.Remove(comboHabitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComboHabitacionExists(int id)
        {
            return (_context.ComboHabitacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
