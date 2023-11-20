using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.TipoHabitacion;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextTipoHabitacion : DbContext
    {
        public WebApplicationApiHotelContextTipoHabitacion (DbContextOptions<WebApplicationApiHotelContextTipoHabitacion> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.TipoHabitacion.TipoHabitacion> TipoHabitacion { get; set; } = default!;
    }
}
