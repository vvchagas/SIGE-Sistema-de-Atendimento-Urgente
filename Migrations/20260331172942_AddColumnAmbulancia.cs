using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGEApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnAmbulancia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Ambulancias",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Ambulancias",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Ambulancias",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Ambulancias");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Ambulancias");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ambulancias");

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
