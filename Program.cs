using ApiCuentaAhorros.Extensiones;
using ApiCuentaAhorros.Servicios.Calculos;
using ApiCuentaAhorros.Servicios.Simulaciones;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AgregarServiciosAplicacion(
    builder.Configuration
);

builder.Services.AddTransient<
    IServicioCalculos,
    ServicioCalculos
>();

builder.Services.AddTransient<
    IServicioSimulaciones,
    ServicioSimulaciones
>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();

app.Run();
