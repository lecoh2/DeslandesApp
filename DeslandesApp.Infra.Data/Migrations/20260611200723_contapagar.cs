using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class contapagar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CONTAPAIID",
                table: "CONTA_PAGAR",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NUMEROPARCELA",
                table: "CONTA_PAGAR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PARCELADO",
                table: "CONTA_PAGAR",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TOTALPARCELAS",
                table: "CONTA_PAGAR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_PAGAR_CONTAPAIID",
                table: "CONTA_PAGAR",
                column: "CONTAPAIID");

            migrationBuilder.AddForeignKey(
                name: "FK_CONTA_PAGAR_CONTA_PAGAR_CONTAPAIID",
                table: "CONTA_PAGAR",
                column: "CONTAPAIID",
                principalTable: "CONTA_PAGAR",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CONTA_PAGAR_CONTA_PAGAR_CONTAPAIID",
                table: "CONTA_PAGAR");

            migrationBuilder.DropIndex(
                name: "IX_CONTA_PAGAR_CONTAPAIID",
                table: "CONTA_PAGAR");

            migrationBuilder.DropColumn(
                name: "CONTAPAIID",
                table: "CONTA_PAGAR");

            migrationBuilder.DropColumn(
                name: "NUMEROPARCELA",
                table: "CONTA_PAGAR");

            migrationBuilder.DropColumn(
                name: "PARCELADO",
                table: "CONTA_PAGAR");

            migrationBuilder.DropColumn(
                name: "TOTALPARCELAS",
                table: "CONTA_PAGAR");
        }
    }
}
