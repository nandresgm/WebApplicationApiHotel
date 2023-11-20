using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.DetalleHabitacion;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextDetalleHabitaciones : DbContext
    {
        public WebApplicationApiHotelContextDetalleHabitaciones (DbContextOptions<WebApplicationApiHotelContextDetalleHabitaciones> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.DetalleHabitacion.DetalleHabitacion> DetalleHabitacion { get; set; } = default!;
    }
}
