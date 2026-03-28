using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProcessoHisotrico2322 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ETIQUETA",
                table: "PROCESSOS");

            migrationBuilder.CreateTable(
                name: "GRUPOCLIENTEPROCESSO",
                columns: table => new
                {
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOCLIENTEPROCESSO", x => new { x.PESSOAID, x.PROCESSOID });
                    table.ForeignKey(
                        name: "FK_GRUPOCLIENTEPROCESSO_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOCLIENTEPROCESSO_PROCESSOS_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOCLIENTEPROCESSO_PROCESSOID",
                table: "GRUPOCLIENTEPROCESSO",
                column: "PROCESSOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRUPOCLIENTEPROCESSO");

            migrationBuilder.AddColumn<int>(
                name: "ETIQUETA",
                table: "PROCESSOS",
                type: "int",
                nullable: true);
        }
    }
}
