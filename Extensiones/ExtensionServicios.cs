using ApiCuentaAhorros.BaseDatos;
using Microsoft.EntityFrameworkCore;

namespace ApiCuentaAhorros.Extensiones;

public static class ExtensionServicios
{
    public static IServiceCollection AgregarServiciosAplicacion(
        this IServiceCollection servicios,
        IConfiguration configuracion
    )
    {
        string conexionSQLite = configuracion.GetConnectionString(
            "ConexionSQLite"
        ) ?? throw new InvalidOperationException(
            "No se encontro la cadena de conexion ConexionSQLite."
        );

        servicios.AddControllers();
        servicios.AddOpenApi();

        servicios.AddDbContext<ContextoBaseDatos>(
            opciones => opciones.UseSqlite(conexionSQLite)
        );

        return servicios;
    }
}
