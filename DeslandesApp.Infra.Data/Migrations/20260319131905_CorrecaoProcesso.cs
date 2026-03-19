using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoProcesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RESPONSAVEL",
                table: "PROCESSOS");

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIORESPONSAVELID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_USUARIORESPONSAVELID",
                table: "PROCESSOS",
                column: "USUARIORESPONSAVELID");

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIORESPONSAVELID",
                table: "PROCESSOS",
                column: "USUARIORESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIORESPONSAVELID",
                table: "PROCESSOS");

            migrationBuilder.DropIndex(
                name: "IX_PROCESSOS_USUARIORESPONSAVELID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "USUARIORESPONSAVELID",
                table: "PROCESSOS");

            migrationBuilder.AddColumn<string>(
                name: "RESPONSAVEL",
                table: "PROCESSOS",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);
        }
    }
}
