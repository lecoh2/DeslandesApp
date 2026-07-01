using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class webjurpubli2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ANOPUBLICACAO",
                table: "WEBJURPUBLICACAO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CIDADEPUBLICACAO",
                table: "WEBJURPUBLICACAO",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CODGRUPO",
                table: "WEBJURPUBLICACAO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CODINTEGRACAO",
                table: "WEBJURPUBLICACAO",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CODVINCULO",
                table: "WEBJURPUBLICACAO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATADIVULGACAO",
                table: "WEBJURPUBLICACAO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DESCRICAODIARIO",
                table: "WEBJURPUBLICACAO",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EDICAODIARIO",
                table: "WEBJURPUBLICACAO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NOMEVINCULO",
                table: "WEBJURPUBLICACAO",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OABESTADO",
                table: "WEBJURPUBLICACAO",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OABNUMERO",
                table: "WEBJURPUBLICACAO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PAGINAFINAL",
                table: "WEBJURPUBLICACAO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PAGINAINICIAL",
                table: "WEBJURPUBLICACAO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PUBLICACAOEXPORTADA",
                table: "WEBJURPUBLICACAO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UFPUBLICACAO",
                table: "WEBJURPUBLICACAO",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ANOPUBLICACAO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "CIDADEPUBLICACAO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "CODGRUPO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "CODINTEGRACAO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "CODVINCULO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "DATADIVULGACAO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "DESCRICAODIARIO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "EDICAODIARIO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "NOMEVINCULO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "OABESTADO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "OABNUMERO",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "PAGINAFINAL",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "PAGINAINICIAL",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "PUBLICACAOEXPORTADA",
                table: "WEBJURPUBLICACAO");

            migrationBuilder.DropColumn(
                name: "UFPUBLICACAO",
                table: "WEBJURPUBLICACAO");
        }
    }
}
