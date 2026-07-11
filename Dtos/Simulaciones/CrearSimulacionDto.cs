namespace ApiCuentaAhorros.Dtos.Simulaciones;

public class CrearSimulacionDto
{
    public decimal DepositoInicial { get; set; }

    public decimal TasaInteresAnual { get; set; }

    public int PlazoAnios { get; set; }
}
