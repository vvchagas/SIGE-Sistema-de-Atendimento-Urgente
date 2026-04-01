using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGEApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "AspNetUsers");
        }
    }
}
