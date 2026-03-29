using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProcessoHisotrico23223 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRUPOENVOLVIDOSPROCESSO",
                columns: table => new
                {
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOENVOLVIDOSPROCESSO", x => new { x.PESSOAID, x.PROCESSOID });
                    table.ForeignKey(
                        name: "FK_GRUPOENVOLVIDOSPROCESSO_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOENVOLVIDOSPROCESSO_PROCESSOS_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GRUPOETIQUETASPROCESSOS",
                columns: table => new
                {
                    ETIQUETAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOETIQUETASPROCESSOS", x => new { x.ETIQUETAID, x.PROCESSOID });
                    table.ForeignKey(
                        name: "FK_GRUPOETIQUETASPROCESSOS_ETIQUETA_ETIQUETAID",
                        column: x => x.ETIQUETAID,
                        principalTable: "ETIQUETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOETIQUETASPROCESSOS_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GRUPOETIQUETASPROCESSOS_PROCESSOS_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOENVOLVIDOSPROCESSO_PROCESSOID",
                table: "GRUPOENVOLVIDOSPROCESSO",
                column: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOETIQUETASPROCESSOS_PESSOAID",
                table: "GRUPOETIQUETASPROCESSOS",
                column: "PESSOAID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOETIQUETASPROCESSOS_PROCESSOID",
                table: "GRUPOETIQUETASPROCESSOS",
                column: "PROCESSOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRUPOENVOLVIDOSPROCESSO");

            migrationBuilder.DropTable(
                name: "GRUPOETIQUETASPROCESSOS");
        }
    }
}
