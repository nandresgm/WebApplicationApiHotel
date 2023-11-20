using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Data;
using WebApplicationApiHotel.Models.LoginUsuarios;

namespace WebApplicationApiHotel.Controllers.LoginUsuarioses
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginUsuariosesController : ControllerBase
    {
        private readonly WebApplicationApiHotelContextLoginUsuarios _context;

        public LoginUsuariosesController(WebApplicationApiHotelContextLoginUsuarios context)
        {
            _context = context;
        }

        // GET: api/LoginUsuarioses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginUsuarios>>> GetLoginUsuarios()
        {
          if (_context.LoginUsuarios == null)
          {
              return NotFound();
          }
            return await _context.LoginUsuarios.ToListAsync();
        }

        // GET: api/LoginUsuarioses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginUsuarios>> GetLoginUsuarios(int id)
        {
          if (_context.LoginUsuarios == null)
          {
              return NotFound();
          }
            var loginUsuarios = await _context.LoginUsuarios.FindAsync(id);

            if (loginUsuarios == null)
            {
                return NotFound();
            }

            return loginUsuarios;
        }

        // PUT: api/LoginUsuarioses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginUsuarios(int id, LoginUsuarios loginUsuarios)
        {
            if (id != loginUsuarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(loginUsuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginUsuariosExists(id))
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


        [HttpPost]
        public async Task<ActionResult<LoginUsuarios>> IniciarSesion (LoginUsuarios loginUsuarios)
        {
            if (_context.LoginUsuarios == null)
            {
                return Problem("Entity set 'WebApplicationApiHotelContextLoginUsuarios.LoginUsuarios'  is null.");
            }
            var user = _context.ValidarUsuario(loginUsuarios.user, loginUsuarios.llave);
           
            if (user == null) {

                return Problem("Error 'Credenciales'  Incorrectas.");
            }

            var Usuarios = await _context.LoginUsuarios.FindAsync(user.Id);

            if (Usuarios == null)
            {
                return NotFound();
            }

            return loginUsuarios;


        }



        // DELETE: api/LoginUsuarioses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginUsuarios(int id)
        {
            if (_context.LoginUsuarios == null)
            {
                return NotFound();
            }
            var loginUsuarios = await _context.LoginUsuarios.FindAsync(id);
            if (loginUsuarios == null)
            {
                return NotFound();
            }

            _context.LoginUsuarios.Remove(loginUsuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginUsuariosExists(int id)
        {
            return (_context.LoginUsuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
