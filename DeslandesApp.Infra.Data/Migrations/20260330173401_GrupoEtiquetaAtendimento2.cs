using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoEtiquetaAtendimento2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOETIQUETASATENDIMENTOS_ATENDIMENTO_ATENDIMENTOID",
                table: "GRUPOETIQUETASATENDIMENTOS");

            migrationBuilder.DropTable(
                name: "GRUPOATENDIMENTOETIQUETA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATENDIMENTO_ETIQUETA",
                table: "GRUPOETIQUETASATENDIMENTOS");

            migrationBuilder.CreateTable(
                name: "GRUPOATENDIMENTOETIQUETA",
                columns: table => new
                {
                    ATENDIMENTOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ETIQUETAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOATENDIMENTOETIQUETA", x => new { x.ATENDIMENTOID, x.ETIQUETAID });
                    table.ForeignKey(
                        name: "FK_ATENDIMENTO_ETIQUETA",
                        column: x => x.ATENDIMENTOID,
                        principalTable: "ATENDIMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOATENDIMENTOETIQUETA_ETIQUETA_ETIQUETAID",
                        column: x => x.ETIQUETAID,
                        principalTable: "ETIQUETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOATENDIMENTOETIQUETA_ETIQUETAID",
                table: "GRUPOATENDIMENTOETIQUETA",
                column: "ETIQUETAID");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOETIQUETASATENDIMENTOS_ATENDIMENTO_ATENDIMENTOID",
                table: "GRUPOETIQUETASATENDIMENTOS",
                column: "ATENDIMENTOID",
                principalTable: "ATENDIMENTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
