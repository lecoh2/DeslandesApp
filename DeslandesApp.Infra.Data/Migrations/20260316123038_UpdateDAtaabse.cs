using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDAtaabse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PESSOA_HISTORICO",
                table: "PESSOA_HISTORICO");

            migrationBuilder.RenameTable(
                name: "PESSOA_HISTORICO",
                newName: "PESSOAHISTORICO");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOA_HISTORICO_USUARIO_ID",
                table: "PESSOAHISTORICO",
                newName: "IX_PESSOAHISTORICO_USUARIO_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOA_HISTORICO_PESSOA_ID",
                table: "PESSOAHISTORICO",
                newName: "IX_PESSOAHISTORICO_PESSOA_ID");

            migrationBuilder.AlterColumn<string>(
                name: "OBSERVACOES",
                table: "PESSOAHISTORICO",
                type: "VARCHAR(255)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATAALTERACAO",
                table: "PESSOAHISTORICO",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DADOSDEPOIS",
                table: "PESSOAHISTORICO",
                type: "VARCHAR(MAX)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "DADOSANTES",
                table: "PESSOAHISTORICO",
                type: "VARCHAR(MAX)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PESSOAHISTORICO",
                table: "PESSOAHISTORICO",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PESSOAHISTORICO",
                table: "PESSOAHISTORICO");

            migrationBuilder.RenameTable(
                name: "PESSOAHISTORICO",
                newName: "PESSOA_HISTORICO");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAHISTORICO_USUARIO_ID",
                table: "PESSOA_HISTORICO",
                newName: "IX_PESSOA_HISTORICO_USUARIO_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAHISTORICO_PESSOA_ID",
                table: "PESSOA_HISTORICO",
                newName: "IX_PESSOA_HISTORICO_PESSOA_ID");

            migrationBuilder.AlterColumn<string>(
                name: "OBSERVACOES",
                table: "PESSOA_HISTORICO",
                type: "VARCHAR(255)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATAALTERACAO",
                table: "PESSOA_HISTORICO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DADOSDEPOIS",
                table: "PESSOA_HISTORICO",
                type: "VARCHAR(MAX)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DADOSANTES",
                table: "PESSOA_HISTORICO",
                type: "VARCHAR(MAX)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PESSOA_HISTORICO",
                table: "PESSOA_HISTORICO",
                column: "Id");
        }
    }
}
