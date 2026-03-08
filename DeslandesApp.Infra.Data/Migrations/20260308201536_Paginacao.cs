using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Paginacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_UsuarioId",
                table: "LOGINHISTORY");

            migrationBuilder.DropIndex(
                name: "IX_LOGINHISTORY_UsuarioId",
                table: "LOGINHISTORY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FAILEDLOGINATTEMPT",
                table: "FAILEDLOGINATTEMPT");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "LOGINHISTORY");

            migrationBuilder.RenameTable(
                name: "FAILEDLOGINATTEMPT",
                newName: "FAILEDLOGINATTEMPTS");

            migrationBuilder.RenameColumn(
                name: "UserAgent",
                table: "LOGINHISTORY",
                newName: "USERAGENT");

            migrationBuilder.RenameColumn(
                name: "Mensagem",
                table: "LOGINHISTORY",
                newName: "MENSAGEM");

            migrationBuilder.RenameColumn(
                name: "IpAcesso",
                table: "LOGINHISTORY",
                newName: "IPACESSO");

            migrationBuilder.RenameColumn(
                name: "UserAgent",
                table: "FAILEDLOGINATTEMPTS",
                newName: "USERAGENT");

            migrationBuilder.RenameColumn(
                name: "Mensagem",
                table: "FAILEDLOGINATTEMPTS",
                newName: "MENSAGEM");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "FAILEDLOGINATTEMPTS",
                newName: "LOGIN");

            migrationBuilder.RenameColumn(
                name: "IpAcesso",
                table: "FAILEDLOGINATTEMPTS",
                newName: "IPACESSO");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "FAILEDLOGINATTEMPTS",
                newName: "IDUSUARIO");

            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "FAILEDLOGINATTEMPTS",
                newName: "DATAHORA");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FAILEDLOGINATTEMPTS",
                newName: "IDFAILEDLOGINATTEMPT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FAILEDLOGINATTEMPTS",
                table: "FAILEDLOGINATTEMPTS",
                column: "IDFAILEDLOGINATTEMPT");

            migrationBuilder.CreateIndex(
                name: "IX_LOGINHISTORY_IdUsuario",
                table: "LOGINHISTORY",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_FAILEDLOGINATTEMPTS_IDUSUARIO",
                table: "FAILEDLOGINATTEMPTS",
                column: "IDUSUARIO");

            migrationBuilder.AddForeignKey(
                name: "FK_FAILEDLOGINATTEMPTS_USUARIOS_IDUSUARIO",
                table: "FAILEDLOGINATTEMPTS",
                column: "IDUSUARIO",
                principalTable: "USUARIOS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_IdUsuario",
                table: "LOGINHISTORY",
                column: "IdUsuario",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FAILEDLOGINATTEMPTS_USUARIOS_IDUSUARIO",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_IdUsuario",
                table: "LOGINHISTORY");

            migrationBuilder.DropIndex(
                name: "IX_LOGINHISTORY_IdUsuario",
                table: "LOGINHISTORY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FAILEDLOGINATTEMPTS",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropIndex(
                name: "IX_FAILEDLOGINATTEMPTS_IDUSUARIO",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.RenameTable(
                name: "FAILEDLOGINATTEMPTS",
                newName: "FAILEDLOGINATTEMPT");

            migrationBuilder.RenameColumn(
                name: "USERAGENT",
                table: "LOGINHISTORY",
                newName: "UserAgent");

            migrationBuilder.RenameColumn(
                name: "MENSAGEM",
                table: "LOGINHISTORY",
                newName: "Mensagem");

            migrationBuilder.RenameColumn(
                name: "IPACESSO",
                table: "LOGINHISTORY",
                newName: "IpAcesso");

            migrationBuilder.RenameColumn(
                name: "USERAGENT",
                table: "FAILEDLOGINATTEMPT",
                newName: "UserAgent");

            migrationBuilder.RenameColumn(
                name: "MENSAGEM",
                table: "FAILEDLOGINATTEMPT",
                newName: "Mensagem");

            migrationBuilder.RenameColumn(
                name: "LOGIN",
                table: "FAILEDLOGINATTEMPT",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "IPACESSO",
                table: "FAILEDLOGINATTEMPT",
                newName: "IpAcesso");

            migrationBuilder.RenameColumn(
                name: "IDUSUARIO",
                table: "FAILEDLOGINATTEMPT",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "DATAHORA",
                table: "FAILEDLOGINATTEMPT",
                newName: "DataHora");

            migrationBuilder.RenameColumn(
                name: "IDFAILEDLOGINATTEMPT",
                table: "FAILEDLOGINATTEMPT",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "LOGINHISTORY",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FAILEDLOGINATTEMPT",
                table: "FAILEDLOGINATTEMPT",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LOGINHISTORY_UsuarioId",
                table: "LOGINHISTORY",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_LOGINHISTORY_USUARIOS_UsuarioId",
                table: "LOGINHISTORY",
                column: "UsuarioId",
                principalTable: "USUARIOS",
                principalColumn: "Id");
        }
    }
}
