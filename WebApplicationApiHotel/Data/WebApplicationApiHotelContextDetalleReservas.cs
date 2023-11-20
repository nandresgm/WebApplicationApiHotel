using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.DetalleReserva;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextDetalleReservas : DbContext
    {
        public WebApplicationApiHotelContextDetalleReservas (DbContextOptions<WebApplicationApiHotelContextDetalleReservas> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.DetalleReserva.DetalleReserva> DetalleReserva { get; set; } = default!;
    }
}
