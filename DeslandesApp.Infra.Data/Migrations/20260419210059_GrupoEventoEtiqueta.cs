using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoEventoEtiqueta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRUPOEVENTOETIQUETAS",
                columns: table => new
                {
                    EVENDOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ETIQUETAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOEVENTOETIQUETAS", x => new { x.EVENDOID, x.ETIQUETAID });
                    table.ForeignKey(
                        name: "FK_EVENTOETIQUETA_ETIQUETA",
                        column: x => x.ETIQUETAID,
                        principalTable: "ETIQUETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EVENTOETIQUETA_EVENTO",
                        column: x => x.EVENDOID,
                        principalTable: "EVENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOEVENTOETIQUETAS_ETIQUETAID",
                table: "GRUPOEVENTOETIQUETAS",
                column: "ETIQUETAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRUPOEVENTOETIQUETAS");
        }
    }
}
