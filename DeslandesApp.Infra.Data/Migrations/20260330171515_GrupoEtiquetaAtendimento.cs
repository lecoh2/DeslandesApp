using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoEtiquetaAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRUPOETIQUETASATENDIMENTOS",
                columns: table => new
                {
                    ETIQUETAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ATENDIMENTOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOETIQUETASATENDIMENTOS", x => new { x.ETIQUETAID, x.ATENDIMENTOID });
                    table.ForeignKey(
                        name: "FK_GRUPOETIQUETASATENDIMENTOS_ATENDIMENTO_ATENDIMENTOID",
                        column: x => x.ATENDIMENTOID,
                        principalTable: "ATENDIMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOETIQUETASATENDIMENTOS_ETIQUETA_ETIQUETAID",
                        column: x => x.ETIQUETAID,
                        principalTable: "ETIQUETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOETIQUETASATENDIMENTOS_ATENDIMENTOID",
                table: "GRUPOETIQUETASATENDIMENTOS",
                column: "ATENDIMENTOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRUPOETIQUETASATENDIMENTOS");
        }
    }
}
