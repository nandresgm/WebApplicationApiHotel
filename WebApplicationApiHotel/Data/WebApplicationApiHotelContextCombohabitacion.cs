using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.ComboHabitacion;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextCombohabitacion : DbContext
    {
        public WebApplicationApiHotelContextCombohabitacion (DbContextOptions<WebApplicationApiHotelContextCombohabitacion> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.ComboHabitacion.ComboHabitacion> ComboHabitacion { get; set; } = default!;
    }
}
