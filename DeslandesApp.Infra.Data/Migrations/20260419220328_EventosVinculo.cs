using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventosVinculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ATENDIMENTOID",
                table: "EVENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CASOID",
                table: "EVENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PROCESSOID",
                table: "EVENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TIPOVINCULO",
                table: "EVENTO",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_ATENDIMENTOID",
                table: "EVENTO",
                column: "ATENDIMENTOID");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_CASOID",
                table: "EVENTO",
                column: "CASOID");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_PROCESSOID",
                table: "EVENTO",
                column: "PROCESSOID");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTO_ATENDIMENTO",
                table: "EVENTO",
                column: "ATENDIMENTOID",
                principalTable: "ATENDIMENTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTO_CASO",
                table: "EVENTO",
                column: "CASOID",
                principalTable: "CASO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTO_PROCESSO",
                table: "EVENTO",
                column: "PROCESSOID",
                principalTable: "PROCESSOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENTO_ATENDIMENTO",
                table: "EVENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_EVENTO_CASO",
                table: "EVENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_EVENTO_PROCESSO",
                table: "EVENTO");

            migrationBuilder.DropIndex(
                name: "IX_EVENTO_ATENDIMENTOID",
                table: "EVENTO");

            migrationBuilder.DropIndex(
                name: "IX_EVENTO_CASOID",
                table: "EVENTO");

            migrationBuilder.DropIndex(
                name: "IX_EVENTO_PROCESSOID",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "ATENDIMENTOID",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "CASOID",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "PROCESSOID",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "TIPOVINCULO",
                table: "EVENTO");
        }
    }
}
