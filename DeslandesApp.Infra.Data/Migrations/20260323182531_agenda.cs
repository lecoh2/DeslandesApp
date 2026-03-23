using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class agenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATA",
                table: "TAREFA",
                newName: "DATACADASTRO");

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCRIACAOID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCRIACAOID",
                table: "EVENTO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TAREFA_USUARIOCRIACAOID",
                table: "TAREFA",
                column: "USUARIOCRIACAOID");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_USUARIOCRIACAOID",
                table: "EVENTO",
                column: "USUARIOCRIACAOID");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTO_USUARIOS_USUARIOCRIACAOID",
                table: "EVENTO",
                column: "USUARIOCRIACAOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_USUARIOS_USUARIOCRIACAOID",
                table: "TAREFA",
                column: "USUARIOCRIACAOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENTO_USUARIOS_USUARIOCRIACAOID",
                table: "EVENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_USUARIOS_USUARIOCRIACAOID",
                table: "TAREFA");

            migrationBuilder.DropIndex(
                name: "IX_TAREFA_USUARIOCRIACAOID",
                table: "TAREFA");

            migrationBuilder.DropIndex(
                name: "IX_EVENTO_USUARIOCRIACAOID",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "USUARIOCRIACAOID",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "USUARIOCRIACAOID",
                table: "EVENTO");

            migrationBuilder.RenameColumn(
                name: "DATACADASTRO",
                table: "TAREFA",
                newName: "DATA");
        }
    }
}
