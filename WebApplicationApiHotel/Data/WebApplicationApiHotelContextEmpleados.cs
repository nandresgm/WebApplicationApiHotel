using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.Empleado;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextEmpleados : DbContext
    {
        public WebApplicationApiHotelContextEmpleados (DbContextOptions<WebApplicationApiHotelContextEmpleados> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.Empleado.Empleado> Empleado { get; set; } = default!;
    }
}
