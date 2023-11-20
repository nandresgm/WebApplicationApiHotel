using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.Reserva;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextReserva : DbContext
    {
        public WebApplicationApiHotelContextReserva (DbContextOptions<WebApplicationApiHotelContextReserva> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.Reserva.Reserva> Reserva { get; set; } = default!;
    }
}
