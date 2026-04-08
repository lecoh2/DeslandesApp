using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoPessoasEtiquetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_ETIQUETA_ETIQUETAID",
                table: "PESSOA");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_ETIQUETAID",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "ETIQUETAID",
                table: "PESSOA");

            migrationBuilder.CreateTable(
                name: "GRUPOPESSOASETIQUETAS",
                columns: table => new
                {
                    ETIQUETAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOPESSOASETIQUETAS", x => new { x.ETIQUETAID, x.PESSOAID });
                    table.ForeignKey(
                        name: "FK_GRUPOPESSOASETIQUETAS_ETIQUETA_ETIQUETAID",
                        column: x => x.ETIQUETAID,
                        principalTable: "ETIQUETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOPESSOASETIQUETAS_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOPESSOASETIQUETAS_PESSOAID",
                table: "GRUPOPESSOASETIQUETAS",
                column: "PESSOAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRUPOPESSOASETIQUETAS");

            migrationBuilder.AddColumn<Guid>(
                name: "ETIQUETAID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_ETIQUETAID",
                table: "PESSOA",
                column: "ETIQUETAID");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_ETIQUETA_ETIQUETAID",
                table: "PESSOA",
                column: "ETIQUETAID",
                principalTable: "ETIQUETA",
                principalColumn: "ID");
        }
    }
}
