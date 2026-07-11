using ApiCuentaAhorros.Dtos.Simulaciones;

namespace ApiCuentaAhorros.Servicios.Simulaciones;

public interface IServicioSimulaciones
{
    Task<SimulacionRespuestaDto> CrearAsync(
        CrearSimulacionDto dto
    );

    Task<List<SimulacionRespuestaDto>> ObtenerTodasAsync();

    Task<SimulacionRespuestaDto?> ObtenerPorIdAsync(
        int id
    );

    Task<List<ProyeccionMensualDto>?> ObtenerProyeccionMensualAsync(
        int id
    );

    Task<List<ProyeccionAnualDto>?> ObtenerProyeccionAnualAsync(
        int id
    );
}
