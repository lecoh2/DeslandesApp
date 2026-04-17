using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class casogrupo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOETIQUETACASOS_CASO_CASOID",
                table: "GRUPOETIQUETACASOS");

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "CASO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CASO_USUARIOCADASTROID",
                table: "CASO",
                column: "USUARIOCADASTROID");

            migrationBuilder.AddForeignKey(
                name: "FK_CASO_USUARIOS_USUARIOCADASTROID",
                table: "CASO",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CASO_ETIQUETA",
                table: "GRUPOETIQUETACASOS",
                column: "CASOID",
                principalTable: "CASO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CASO_USUARIOS_USUARIOCADASTROID",
                table: "CASO");

            migrationBuilder.DropForeignKey(
                name: "FK_CASO_ETIQUETA",
                table: "GRUPOETIQUETACASOS");

            migrationBuilder.DropIndex(
                name: "IX_CASO_USUARIOCADASTROID",
                table: "CASO");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "CASO");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOETIQUETACASOS_CASO_CASOID",
                table: "GRUPOETIQUETACASOS",
                column: "CASOID",
                principalTable: "CASO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
