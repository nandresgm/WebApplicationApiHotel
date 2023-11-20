using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.Clientes;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextClientes : DbContext
    {
        public WebApplicationApiHotelContextClientes (DbContextOptions<WebApplicationApiHotelContextClientes> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.Clientes.Cliente> Cliente { get; set; } = default!;
    }
}
