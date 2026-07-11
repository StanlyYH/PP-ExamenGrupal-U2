using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCuentaAhorros.Migraciones
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Simulaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepositoInicial = table.Column<decimal>(type: "TEXT", nullable: false),
                    TasaInteresAnual = table.Column<decimal>(type: "TEXT", nullable: false),
                    PlazoAnios = table.Column<int>(type: "INTEGER", nullable: false),
                    MontoFinal = table.Column<decimal>(type: "TEXT", nullable: false),
                    InteresTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulaciones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Simulaciones");
        }
    }
}
