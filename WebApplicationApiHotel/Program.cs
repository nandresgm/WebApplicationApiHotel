using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationApiHotel.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplicationApiHotelContextTipoHabitacion>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextTipoHabitacion") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextTipoHabitacion' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextLoginUsuarios>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextLoginUsuarios") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextLoginUsuarios' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextTipoDocumentos>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextTipoDocumentos") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextTipoDocumentos' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextReserva>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextReserva") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextReserva' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextHotels>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextHotels") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextHotels' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextHabitaciones>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextHabitaciones") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextHabitaciones' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextFactura>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextFactura") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextFactura' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextEmpleados>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextEmpleados") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextEmpleados' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextDetalleReservas>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextDetalleReservas") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextDetalleReservas' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextDetalleHabitaciones>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextDetalleHabitaciones") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextDetalleHabitaciones' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextDetalleFacturas>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextDetalleFacturas") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextDetalleFacturas' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextCombohabitacion>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextCombohabitacion") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextCombohabitacion' not found.")));
builder.Services.AddDbContext<WebApplicationApiHotelContextClientes>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationApiHotelContextClientes") ?? throw new InvalidOperationException("Connection string 'WebApplicationApiHotelContextClientes' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
