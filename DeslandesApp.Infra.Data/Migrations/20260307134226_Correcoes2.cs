using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Correcoes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_PESSOA_Id",
                table: "USUARIOS");

            migrationBuilder.AlterColumn<Guid>(
                name: "USUARIO_ID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SEXO_ID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATACADASTRO",
                table: "PESSOA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_USUARIO_ID",
                table: "PESSOA",
                column: "USUARIO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_USUARIOS_USUARIO_ID",
                table: "PESSOA",
                column: "USUARIO_ID",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_USUARIOS_USUARIO_ID",
                table: "PESSOA");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_USUARIO_ID",
                table: "PESSOA");

            migrationBuilder.AlterColumn<Guid>(
                name: "USUARIO_ID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SEXO_ID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATACADASTRO",
                table: "PESSOA",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_PESSOA_Id",
                table: "USUARIOS",
                column: "Id",
                principalTable: "PESSOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
