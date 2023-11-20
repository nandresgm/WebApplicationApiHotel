using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiHotel.Models.TipoDocumento;

namespace WebApplicationApiHotel.Data
{
    public class WebApplicationApiHotelContextTipoDocumentos : DbContext
    {
        public WebApplicationApiHotelContextTipoDocumentos (DbContextOptions<WebApplicationApiHotelContextTipoDocumentos> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationApiHotel.Models.TipoDocumento.TipoDocumento> TipoDocumento { get; set; } = default!;
    }
}
