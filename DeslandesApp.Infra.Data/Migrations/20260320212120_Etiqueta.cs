using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Etiqueta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ETIQUETA",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "ETIQUETA",
                table: "ATENDIMENTO");

            migrationBuilder.AddColumn<Guid>(
                name: "ETIQUETAID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ETIQUETA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETIQUETA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ATENDIMENTO_ETIQUETA",
                columns: table => new
                {
                    ATENDIMENTOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ETIQUETAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATENDIMENTO_ETIQUETA", x => new { x.ATENDIMENTOID, x.ETIQUETAID });
                    table.ForeignKey(
                        name: "FK_ATENDIMENTO_ETIQUETA",
                        column: x => x.ATENDIMENTOID,
                        principalTable: "ATENDIMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ATENDIMENTO_ETIQUETA_ETIQUETA_ETIQUETAID",
                        column: x => x.ETIQUETAID,
                        principalTable: "ETIQUETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_ETIQUETAID",
                table: "PESSOA",
                column: "ETIQUETAID");

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTO_ETIQUETA_ETIQUETAID",
                table: "ATENDIMENTO_ETIQUETA",
                column: "ETIQUETAID");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_ETIQUETA_ETIQUETAID",
                table: "PESSOA",
                column: "ETIQUETAID",
                principalTable: "ETIQUETA",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_ETIQUETA_ETIQUETAID",
                table: "PESSOA");

            migrationBuilder.DropTable(
                name: "ATENDIMENTO_ETIQUETA");

            migrationBuilder.DropTable(
                name: "ETIQUETA");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_ETIQUETAID",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "ETIQUETAID",
                table: "PESSOA");

            migrationBuilder.AddColumn<int>(
                name: "ETIQUETA",
                table: "PESSOA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ETIQUETA",
                table: "ATENDIMENTO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
