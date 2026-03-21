using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class tarefaEtiquetaprocesso2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VINCULOID",
                table: "TAREFA");

            migrationBuilder.AlterColumn<int>(
                name: "TIPOVINCULO",
                table: "TAREFA",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "ATENDIMENTOPAIID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CASOID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PROCESSOID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ATENDIMENTOPAIID",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "CASOID",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "PROCESSOID",
                table: "TAREFA");

            migrationBuilder.AlterColumn<int>(
                name: "TIPOVINCULO",
                table: "TAREFA",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VINCULOID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
