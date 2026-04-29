using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ObterProcesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CASOHISTORICO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CASOHISTORICO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CASO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DADOSANTES = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true),
                    DADOSDEPOIS = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "VARCHAR(255)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASOHISTORICO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CASOHISTORICO_CASO",
                        column: x => x.CASO_ID,
                        principalTable: "CASO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CASOHISTORICO_USUARIO",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CASOHISTORICO_CASO_ID",
                table: "CASOHISTORICO",
                column: "CASO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CASOHISTORICO_USUARIO_ID",
                table: "CASOHISTORICO",
                column: "USUARIO_ID");
        }
    }
}
