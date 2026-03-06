using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstruturaInicialCorrecao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_INFORMACOESCOMPLEMENTARES_IdPessoa",
                table: "PESSOA");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_PESSOA_PessoaId",
                table: "PESSOA");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_PESSOA_PessoaJuridica_PessoaId",
                table: "PESSOA");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_IdPessoa",
                table: "PESSOA");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_PessoaId",
                table: "PESSOA");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_PessoaJuridica_PessoaId",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "PessoaJuridica_PessoaId",
                table: "PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_INFORMACOESCOMPLEMENTARES_PESSOA_ID",
                table: "INFORMACOESCOMPLEMENTARES",
                column: "PESSOA_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_INFORMACOESCOMPLEMENTARES_PESSOA_PESSOA_ID",
                table: "INFORMACOESCOMPLEMENTARES",
                column: "PESSOA_ID",
                principalTable: "PESSOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INFORMACOESCOMPLEMENTARES_PESSOA_PESSOA_ID",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropIndex(
                name: "IX_INFORMACOESCOMPLEMENTARES_PESSOA_ID",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaId",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaJuridica_PessoaId",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_IdPessoa",
                table: "PESSOA",
                column: "IdPessoa",
                unique: true,
                filter: "[IdPessoa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_PessoaId",
                table: "PESSOA",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_PessoaJuridica_PessoaId",
                table: "PESSOA",
                column: "PessoaJuridica_PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_INFORMACOESCOMPLEMENTARES_IdPessoa",
                table: "PESSOA",
                column: "IdPessoa",
                principalTable: "INFORMACOESCOMPLEMENTARES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_PESSOA_PessoaId",
                table: "PESSOA",
                column: "PessoaId",
                principalTable: "PESSOA",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_PESSOA_PessoaJuridica_PessoaId",
                table: "PESSOA",
                column: "PessoaJuridica_PessoaId",
                principalTable: "PESSOA",
                principalColumn: "Id");
        }
    }
}
