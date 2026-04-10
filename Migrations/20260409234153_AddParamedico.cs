using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGEApi.Migrations
{
    /// <inheritdoc />
    public partial class AddParamedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Paramedicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Paramedicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Paramedicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentificadorProfissional",
                table: "Paramedicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Paramedicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Ocupado",
                table: "Paramedicos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Paramedicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Paramedicos");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Paramedicos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Paramedicos");

            migrationBuilder.DropColumn(
                name: "IdentificadorProfissional",
                table: "Paramedicos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Paramedicos");

            migrationBuilder.DropColumn(
                name: "Ocupado",
                table: "Paramedicos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Paramedicos");
        }
    }
}
