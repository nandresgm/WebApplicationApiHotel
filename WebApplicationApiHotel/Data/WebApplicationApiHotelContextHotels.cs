using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.Hotel;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextHotels : DbContext
    {
        public WebApplicationApiHotelContextHotels (DbContextOptions<WebApplicationApiHotelContextHotels> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.Hotel.Hotel> Hotel { get; set; } = default!;
    }
}
