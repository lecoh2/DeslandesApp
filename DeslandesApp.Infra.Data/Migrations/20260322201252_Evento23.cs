using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Evento23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ENTIDADEID",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "TIPOVINCULO",
                table: "EVENTO");

            migrationBuilder.AlterColumn<string>(
                name: "DIASSEMANA",
                table: "EVENTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DIASSEMANA",
                table: "EVENTO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "ENTIDADEID",
                table: "EVENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TIPOVINCULO",
                table: "EVENTO",
                type: "int",
                nullable: true);
        }
    }
}
