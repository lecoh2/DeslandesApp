using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class vinculoid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TIPOVINCULO",
                table: "TAREFA",
                newName: "TIPOVINCULOID");

            migrationBuilder.RenameColumn(
                name: "TIPOVINCULO",
                table: "EVENTO",
                newName: "TIPOVINCULOID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATACADASTRO",
                table: "PROCESSOS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "CASO",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "CASO");

            migrationBuilder.RenameColumn(
                name: "TIPOVINCULOID",
                table: "TAREFA",
                newName: "TIPOVINCULO");

            migrationBuilder.RenameColumn(
                name: "TIPOVINCULOID",
                table: "EVENTO",
                newName: "TIPOVINCULO");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATACADASTRO",
                table: "PROCESSOS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
