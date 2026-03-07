using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Correcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_SEXO_SEXO_ID",
                table: "PESSOA");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_PESSOA_PESSOA_ID",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_PESSOA_ID",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "PESSOA_ID",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "IdPessoa",
                table: "PESSOA");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_SEXO_SEXO_ID",
                table: "PESSOA",
                column: "SEXO_ID",
                principalTable: "SEXO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_PESSOA_Id",
                table: "USUARIOS",
                column: "Id",
                principalTable: "PESSOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_SEXO_SEXO_ID",
                table: "PESSOA");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_PESSOA_Id",
                table: "USUARIOS");

            migrationBuilder.AddColumn<Guid>(
                name: "PESSOA_ID",
                table: "USUARIOS",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdPessoa",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_PESSOA_ID",
                table: "USUARIOS",
                column: "PESSOA_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_SEXO_SEXO_ID",
                table: "PESSOA",
                column: "SEXO_ID",
                principalTable: "SEXO",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_PESSOA_PESSOA_ID",
                table: "USUARIOS",
                column: "PESSOA_ID",
                principalTable: "PESSOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
