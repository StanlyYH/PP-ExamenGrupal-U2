using ApiCuentaAhorros.Dtos.Simulaciones;

namespace ApiCuentaAhorros.Servicios.Calculos;

public class ServicioCalculos : IServicioCalculos
{
    public ResultadoCalculoDto CalcularResultado(
        decimal depositoInicial,
        decimal tasaInteresAnual,
        int plazoAnios
    )
    {
        ValidarParametros(depositoInicial, tasaInteresAnual, plazoAnios);

        decimal tasaMensual = tasaInteresAnual / (decimal)12;
        int mesesTotales = plazoAnios * 12;
        decimal saldoActual = depositoInicial;

        for (int mes = 1; mes <= mesesTotales; mes++)
        {
            decimal interesMes = saldoActual * tasaMensual;
            saldoActual += interesMes;
        }

        decimal interesTotal = saldoActual - depositoInicial;

        return new ResultadoCalculoDto
        {
            MontoFinal = Math.Round(saldoActual, 2),
            InteresTotal = Math.Round(interesTotal, 2)
        };
    }

    public List<ProyeccionMensualDto> CalcularProyeccionMensual(
        decimal depositoInicial,
        decimal tasaInteresAnual,
        int plazoAnios
    )
    {
        ValidarParametros(depositoInicial, tasaInteresAnual, plazoAnios);

        decimal tasaMensual = tasaInteresAnual / (decimal)12;
        int mesesTotales = plazoAnios * 12;
        decimal saldoActual = depositoInicial;

        List<ProyeccionMensualDto> proyeccionMensual = [];

        for (int mes = 1; mes <= mesesTotales; mes++)
        {
            decimal interesMes = saldoActual * tasaMensual;
            saldoActual += interesMes;

            proyeccionMensual.Add(new ProyeccionMensualDto
            {
                Mes = mes,
                SaldoAcumulado = Math.Round(saldoActual, 2),
                InteresGeneradoMes = Math.Round(interesMes, 2)
            });
        }

        return proyeccionMensual;
    }

    public List<ProyeccionAnualDto> CalcularProyeccionAnual(
        decimal depositoInicial,
        decimal tasaInteresAnual,
        int plazoAnios
    )
    {
        ValidarParametros(depositoInicial, tasaInteresAnual, plazoAnios);

        decimal tasaMensual = tasaInteresAnual / (decimal)12;
        decimal saldoActual = depositoInicial;

        List<ProyeccionAnualDto> proyeccionAnual = [];

        for (int anio = 1; anio <= plazoAnios; anio++)
        {
            decimal saldoInicioAnio = saldoActual;

            for (int mes = 1; mes <= 12; mes++)
            {
                decimal interesMes = saldoActual * tasaMensual;
                saldoActual += interesMes;
            }

            decimal interesGeneradoAnio = saldoActual - saldoInicioAnio;

            proyeccionAnual.Add(new ProyeccionAnualDto
            {
                Anio = anio,
                SaldoAcumulado = Math.Round(saldoActual, 2),
                InteresGeneradoAnio = Math.Round(interesGeneradoAnio, 2)
            });
        }

        return proyeccionAnual;
    }

    private static void ValidarParametros(
        decimal depositoInicial,
        decimal tasaInteresAnual,
        int plazoAnios
    )
    {
        if (depositoInicial <= 0)
        {
            throw new ArgumentException(
                "El depósito inicial debe ser mayor que cero.",
                nameof(depositoInicial)
            );
        }

        if (tasaInteresAnual <= 0)
        {
            throw new ArgumentException(
                "La tasa de interés anual debe ser mayor que cero.",
                nameof(tasaInteresAnual)
            );
        }

        if (plazoAnios <= 0)
        {
            throw new ArgumentException(
                "El plazo en años debe ser mayor que cero.",
                nameof(plazoAnios)
            );
        }
    }
}