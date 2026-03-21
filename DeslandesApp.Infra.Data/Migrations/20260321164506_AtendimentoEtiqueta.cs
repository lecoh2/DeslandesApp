using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtendimentoEtiqueta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ATENDIMENTOPAIID",
                table: "ATENDIMENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CASOID",
                table: "ATENDIMENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "ATENDIMENTO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "ATENDIMENTO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "RESPONSAVELID",
                table: "ATENDIMENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TIPOVINCULO",
                table: "ATENDIMENTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTO_ATENDIMENTOPAIID",
                table: "ATENDIMENTO",
                column: "ATENDIMENTOPAIID");

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTO_CASOID",
                table: "ATENDIMENTO",
                column: "CASOID");

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTO_RESPONSAVELID",
                table: "ATENDIMENTO",
                column: "RESPONSAVELID");

            migrationBuilder.AddForeignKey(
                name: "FK_ATENDIMENTO_ATENDIMENTO_ATENDIMENTOPAIID",
                table: "ATENDIMENTO",
                column: "ATENDIMENTOPAIID",
                principalTable: "ATENDIMENTO",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ATENDIMENTO_CASO_CASOID",
                table: "ATENDIMENTO",
                column: "CASOID",
                principalTable: "CASO",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ATENDIMENTO_USUARIOS_RESPONSAVELID",
                table: "ATENDIMENTO",
                column: "RESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATENDIMENTO_ATENDIMENTO_ATENDIMENTOPAIID",
                table: "ATENDIMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_ATENDIMENTO_CASO_CASOID",
                table: "ATENDIMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_ATENDIMENTO_USUARIOS_RESPONSAVELID",
                table: "ATENDIMENTO");

            migrationBuilder.DropIndex(
                name: "IX_ATENDIMENTO_ATENDIMENTOPAIID",
                table: "ATENDIMENTO");

            migrationBuilder.DropIndex(
                name: "IX_ATENDIMENTO_CASOID",
                table: "ATENDIMENTO");

            migrationBuilder.DropIndex(
                name: "IX_ATENDIMENTO_RESPONSAVELID",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "ATENDIMENTOPAIID",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "CASOID",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "RESPONSAVELID",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "TIPOVINCULO",
                table: "ATENDIMENTO");
        }
    }
}
