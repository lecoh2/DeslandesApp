using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Correcoes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PESSOA_ValorEmail",
                table: "PESSOA");

            migrationBuilder.RenameColumn(
                name: "DATATATUALIZACAO",
                table: "PESSOA",
                newName: "DATAATUALIZACAO");

            migrationBuilder.RenameColumn(
                name: "ValorEmail",
                table: "PESSOA",
                newName: "EMAIL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATACADASTRO",
                table: "USUARIOS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_EMAIL",
                table: "PESSOA",
                column: "EMAIL",
                unique: true,
                filter: "[EMAIL] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PESSOA_EMAIL",
                table: "PESSOA");

            migrationBuilder.RenameColumn(
                name: "DATAATUALIZACAO",
                table: "PESSOA",
                newName: "DATATATUALIZACAO");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "PESSOA",
                newName: "ValorEmail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATACADASTRO",
                table: "USUARIOS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_ValorEmail",
                table: "PESSOA",
                column: "ValorEmail",
                unique: true,
                filter: "[ValorEmail] IS NOT NULL");
        }
    }
}
