using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.Factura;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextFactura : DbContext
    {
        public WebApplicationApiHotelContextFactura (DbContextOptions<WebApplicationApiHotelContextFactura> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.Factura.Factura> Factura { get; set; } = default!;
    }
}
