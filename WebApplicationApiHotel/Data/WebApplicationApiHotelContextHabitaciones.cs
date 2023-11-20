using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.Habitacion;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextHabitaciones : DbContext
    {
        public WebApplicationApiHotelContextHabitaciones (DbContextOptions<WebApplicationApiHotelContextHabitaciones> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.Habitacion.Habitacion> Habitacion { get; set; } = default!;
    }
}
