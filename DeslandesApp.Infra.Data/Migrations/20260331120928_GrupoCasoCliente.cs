using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoCasoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOCASOCLIENTE_QUALIFICACAO_QUALIFICACAOID",
                table: "GRUPOCASOCLIENTE");

            migrationBuilder.DropIndex(
                name: "IX_GRUPOCASOCLIENTE_QUALIFICACAOID",
                table: "GRUPOCASOCLIENTE");

            migrationBuilder.DropColumn(
                name: "QUALIFICACAOID",
                table: "GRUPOCASOCLIENTE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QUALIFICACAOID",
                table: "GRUPOCASOCLIENTE",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOCASOCLIENTE_QUALIFICACAOID",
                table: "GRUPOCASOCLIENTE",
                column: "QUALIFICACAOID");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOCASOCLIENTE_QUALIFICACAO_QUALIFICACAOID",
                table: "GRUPOCASOCLIENTE",
                column: "QUALIFICACAOID",
                principalTable: "QUALIFICACAO",
                principalColumn: "ID");
        }
    }
}
