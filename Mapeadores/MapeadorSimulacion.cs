using ApiCuentaAhorros.Dtos.Simulaciones;
using ApiCuentaAhorros.Entidades;

namespace ApiCuentaAhorros.Mapeadores;

public static class MapeadorSimulacion
{
    public static SimulacionEntidad CrearDtoAEntidad(
        CrearSimulacionDto dto,
        ResultadoCalculoDto resultado
    )
    {
        return new SimulacionEntidad
        {
            DepositoInicial = dto.DepositoInicial,
            TasaInteresAnual = dto.TasaInteresAnual,
            PlazoAnios = dto.PlazoAnios,
            MontoFinal = resultado.MontoFinal,
            InteresTotal = resultado.InteresTotal,
            FechaCreacion = DateTime.UtcNow
        };
    }

    public static SimulacionRespuestaDto EntidadADto(
        SimulacionEntidad entidad
    )
    {
        return new SimulacionRespuestaDto
        {
            Id = entidad.Id,
            DepositoInicial = Math.Round(entidad.DepositoInicial, 2),
            TasaInteresAnual = entidad.TasaInteresAnual,
            PlazoAnios = entidad.PlazoAnios,
            MontoFinal = Math.Round(entidad.MontoFinal, 2),
            InteresTotal = Math.Round(entidad.InteresTotal, 2),
            FechaCreacion = entidad.FechaCreacion
        };
    }

    public static List<SimulacionRespuestaDto> EntidadesADtos(
        IEnumerable<SimulacionEntidad> entidades
    )
    {
        return entidades
            .Select(EntidadADto)
            .ToList();
    }
}
