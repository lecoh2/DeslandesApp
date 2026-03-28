using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProcessoHisotrico2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOHISTORICO_PROCESSOS_PROCESSOID",
                table: "PROCESSOHISTORICO");

            migrationBuilder.DropColumn(
                name: "IDPROCESSO",
                table: "PROCESSOHISTORICO");

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOHISTORICO_PROCESSOS_PROCESSOID",
                table: "PROCESSOHISTORICO",
                column: "PROCESSOID",
                principalTable: "PROCESSOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOHISTORICO_PROCESSOS_PROCESSOID",
                table: "PROCESSOHISTORICO");

            migrationBuilder.AddColumn<Guid>(
                name: "IDPROCESSO",
                table: "PROCESSOHISTORICO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOHISTORICO_PROCESSOS_PROCESSOID",
                table: "PROCESSOHISTORICO",
                column: "PROCESSOID",
                principalTable: "PROCESSOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
