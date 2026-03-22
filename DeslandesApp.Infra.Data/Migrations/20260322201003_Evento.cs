using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Evento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DATAFIMRECORRENCIA",
                table: "EVENTO",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DIASSEMANA",
                table: "EVENTO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "INTERVALORECORRENCIA",
                table: "EVENTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QUANTIDADEOCORRENCIAS",
                table: "EVENTO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TIPORECORRENCIA",
                table: "EVENTO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DATAFIMRECORRENCIA",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "DIASSEMANA",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "INTERVALORECORRENCIA",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "QUANTIDADEOCORRENCIAS",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "TIPORECORRENCIA",
                table: "EVENTO");
        }
    }
}
