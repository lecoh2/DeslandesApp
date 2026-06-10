using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class contareceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CONTRATOID",
                table: "CONTA_RECEBER",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CONTAPAIID",
                table: "CONTA_RECEBER",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FORMARECEBIMENTO",
                table: "CONTA_RECEBER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NUMEROPARCELA",
                table: "CONTA_RECEBER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PARCELADO",
                table: "CONTA_RECEBER",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TIPOCONTA",
                table: "CONTA_RECEBER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TOTALPARCELAS",
                table: "CONTA_RECEBER",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_RECEBER_CONTAPAIID",
                table: "CONTA_RECEBER",
                column: "CONTAPAIID");

            migrationBuilder.AddForeignKey(
                name: "FK_CONTA_RECEBER_CONTA_RECEBER_CONTAPAIID",
                table: "CONTA_RECEBER",
                column: "CONTAPAIID",
                principalTable: "CONTA_RECEBER",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CONTA_RECEBER_CONTA_RECEBER_CONTAPAIID",
                table: "CONTA_RECEBER");

            migrationBuilder.DropIndex(
                name: "IX_CONTA_RECEBER_CONTAPAIID",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "CONTAPAIID",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "FORMARECEBIMENTO",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "NUMEROPARCELA",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "PARCELADO",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "TIPOCONTA",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "TOTALPARCELAS",
                table: "CONTA_RECEBER");

            migrationBuilder.AlterColumn<Guid>(
                name: "CONTRATOID",
                table: "CONTA_RECEBER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
