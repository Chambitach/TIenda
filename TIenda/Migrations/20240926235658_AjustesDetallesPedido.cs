using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TIenda.Migrations
{
    /// <inheritdoc />
    public partial class AjustesDetallesPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitario",
                table: "DetallesPedido",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "DetallesPedido",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitario",
                table: "DetallesPedido",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "DetallesPedido",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
