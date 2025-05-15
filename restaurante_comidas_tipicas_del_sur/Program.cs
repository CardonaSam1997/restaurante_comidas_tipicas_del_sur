using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Entity;
using restaurante_comidas_tipicas_del_sur.Repository.Impl;
using restaurante_comidas_tipicas_del_sur.Repository;
using restaurante_comidas_tipicas_del_sur.Service.Impl;
using restaurante_comidas_tipicas_del_sur.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<RestauranteComidasDelSurContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IConsultasService, ConsultasService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDetalleFacturaRepository, DetalleFacturaRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();
builder.Services.AddScoped<IMeseroRepository, MeseroRepository>();
builder.Services.AddScoped<ISupervisorRepository, SupervisorRepository>();

builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; 
    });
}
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