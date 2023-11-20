using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Data;
using WebApplicationApiHotel.Models.Clientes;

namespace WebApplicationApiHotel.Controllers.Clientes
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly WebApplicationApiHotelContextClientes _context;

        public ClientesController(WebApplicationApiHotelContextClientes context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {

          if (_context.Cliente == null)
          {
              return NotFound("Clientes no disponibles");
          }
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClientes(int id)
        {
          if (_context.Cliente == null)
          {
              return NotFound();
          }
            var clientes = await _context.Cliente.FindAsync(id);

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(int id, Cliente clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostClientes(Cliente cliente)
        {
          if (_context.Cliente == null)
          {
              return Problem("Entity set 'WebApplicationApiHotelContextClientes.Clientes'  is null.");
          }
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientes", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            if (_context.Cliente == null)
            {
                return NotFound();
            }
            var clientes = await _context.Cliente.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientesExists(int id)
        {
            return (_context.Cliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
