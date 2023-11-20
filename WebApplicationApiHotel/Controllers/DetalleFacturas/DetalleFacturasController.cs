using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Data;
using WebApplicationApiHotel.Models.DetalleFacturas;

namespace WebApplicationApiHotel.Controllers.DetalleFacturas
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetalleFacturasController : ControllerBase
    {
        private readonly WebApplicationApiHotelContextDetalleFacturas _context;

        public DetalleFacturasController(WebApplicationApiHotelContextDetalleFacturas context)
        {
            _context = context;
        }

        // GET: api/DetalleFacturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleFactura>>> GetDetalleFacturas()
        {
          if (_context.DetalleFactura == null)
          {
              return NotFound();
          }
            return await _context.DetalleFactura.ToListAsync();
        }

        // GET: api/DetalleFacturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleFactura>> GetDetalleFacturas(int id)
        {
          if (_context.DetalleFactura == null)
          {
              return NotFound();
          }
            var detalleFacturas = await _context.DetalleFactura.FindAsync(id);

            if (detalleFacturas == null)
            {
                return NotFound();
            }

            return detalleFacturas;
        }

        // PUT: api/DetalleFacturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleFacturas(int id, DetalleFactura detalleFacturas)
        {
            if (id != detalleFacturas.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleFacturas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleFacturasExists(id))
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

        // POST: api/DetalleFacturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleFactura>> PostDetalleFacturas(DetalleFactura detalleFacturas)
        {
          if (_context.DetalleFactura == null)
          {
              return Problem("Entity set 'WebApplicationApiHotelContextDetalleFacturas.DetalleFacturas'  is null.");
          }
            _context.DetalleFactura.Add(detalleFacturas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleFacturas", new { id = detalleFacturas.Id }, detalleFacturas);
        }

        // DELETE: api/DetalleFacturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleFacturas(int id)
        {
            if (_context.DetalleFactura == null)
            {
                return NotFound();
            }
            var detalleFacturas = await _context.DetalleFactura.FindAsync(id);
            if (detalleFacturas == null)
            {
                return NotFound();
            }

            _context.DetalleFactura.Remove(detalleFacturas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleFacturasExists(int id)
        {
            return (_context.DetalleFactura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
