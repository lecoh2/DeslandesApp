using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstruturaInicialCorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_INFORMACOESCOMPLEMENTARES_Id",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "PessoaJuridica_IdPessoa",
                table: "PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_IdPessoa",
                table: "PESSOA",
                column: "IdPessoa",
                unique: true,
                filter: "[IdPessoa] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_INFORMACOESCOMPLEMENTARES_IdPessoa",
                table: "PESSOA",
                column: "IdPessoa",
                principalTable: "INFORMACOESCOMPLEMENTARES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_INFORMACOESCOMPLEMENTARES_IdPessoa",
                table: "PESSOA");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_IdPessoa",
                table: "PESSOA");

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaJuridica_IdPessoa",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_INFORMACOESCOMPLEMENTARES_Id",
                table: "PESSOA",
                column: "Id",
                principalTable: "INFORMACOESCOMPLEMENTARES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
