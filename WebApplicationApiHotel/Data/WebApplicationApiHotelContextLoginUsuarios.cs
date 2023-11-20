using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.LoginUsuarios;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextLoginUsuarios : DbContext
    {
        public WebApplicationApiHotelContextLoginUsuarios (DbContextOptions<WebApplicationApiHotelContextLoginUsuarios> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.LoginUsuarios.LoginUsuarios> LoginUsuarios { get; set; } = default!;



        public LoginUsuarios ValidarUsuario(string usuario, string llave)
        {
            return (LoginUsuarios)LoginUsuarios.Where(item => item.user == usuario && item.llave == llave).FirstOrDefault();
        }
    }
}
