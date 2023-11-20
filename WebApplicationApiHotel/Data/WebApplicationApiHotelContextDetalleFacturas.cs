using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.DetalleFacturas;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextDetalleFacturas : DbContext
    {
        public WebApplicationApiHotelContextDetalleFacturas (DbContextOptions<WebApplicationApiHotelContextDetalleFacturas> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.DetalleFacturas.DetalleFactura> DetalleFactura { get; set; } = default!;
    }
}
