using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGEApi.Migrations
{
    /// <inheritdoc />
    public partial class addModeloColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Ambulancias",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Ambulancias",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Ambulancias",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Ambulancias");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Ambulancias");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Ambulancias",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
