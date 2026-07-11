using ApiCuentaAhorros.Dtos.Simulaciones;

namespace ApiCuentaAhorros.Servicios.Calculos;

public interface IServicioCalculos
{
    ResultadoCalculoDto CalcularResultado(
        decimal depositoInicial,
        decimal tasaInteresAnual,
        int plazoAnios
    );

    List<ProyeccionMensualDto> CalcularProyeccionMensual(
        decimal depositoInicial,
        decimal tasaInteresAnual,
        int plazoAnios
    );

    List<ProyeccionAnualDto> CalcularProyeccionAnual(
        decimal depositoInicial,
        decimal tasaInteresAnual,
        int plazoAnios
    );
}
