namespace ApiCuentaAhorros.Entidades;

public class SimulacionEntidad
{
    public int Id { get; set; }

    public decimal DepositoInicial { get; set; }

    public decimal TasaInteresAnual { get; set; }

    public int PlazoAnios { get; set; }

    public decimal MontoFinal { get; set; }

    public decimal InteresTotal { get; set; }

    public DateTime FechaCreacion { get; set; }
}
