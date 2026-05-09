using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Usuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "ATENDIMENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_USUARIOCADASTROID",
                table: "PROCESSOS",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTO_USUARIOCADASTROID",
                table: "ATENDIMENTO",
                column: "USUARIOCADASTROID");

            migrationBuilder.AddForeignKey(
                name: "FK_ATENDIMENTO_USUARIOS_USUARIOCADASTROID",
                table: "ATENDIMENTO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOCADASTROID",
                table: "PROCESSOS",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATENDIMENTO_USUARIOS_USUARIOCADASTROID",
                table: "ATENDIMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOCADASTROID",
                table: "PROCESSOS");

            migrationBuilder.DropIndex(
                name: "IX_PROCESSOS_USUARIOCADASTROID",
                table: "PROCESSOS");

            migrationBuilder.DropIndex(
                name: "IX_ATENDIMENTO_USUARIOCADASTROID",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "ATENDIMENTO");
        }
    }
}
