using ApiCuentaAhorros.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiCuentaAhorros.BaseDatos;

public class ContextoBaseDatos : DbContext
{
    public ContextoBaseDatos(
        DbContextOptions<ContextoBaseDatos> opciones
    ) : base(opciones)
    {
    }

    public DbSet<SimulacionEntidad> Simulaciones { get; set; } = null!;
}
