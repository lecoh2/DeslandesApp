using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoCasoEtiqueta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRUPOETIQUETACASOS",
                columns: table => new
                {
                    ETIQUETAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CASOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOETIQUETACASOS", x => new { x.ETIQUETAID, x.CASOID });
                    table.ForeignKey(
                        name: "FK_GRUPOETIQUETACASOS_CASO_CASOID",
                        column: x => x.CASOID,
                        principalTable: "CASO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOETIQUETACASOS_ETIQUETA_ETIQUETAID",
                        column: x => x.ETIQUETAID,
                        principalTable: "ETIQUETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOETIQUETACASOS_CASOID",
                table: "GRUPOETIQUETACASOS",
                column: "CASOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRUPOETIQUETACASOS");
        }
    }
}
