using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class autitoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVENTOHISTORICO");

            migrationBuilder.DropTable(
                name: "PESSOAHISTORICO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EVENTOHISTORICO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EVENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DADOSANTES = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true),
                    DADOSDEPOIS = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "VARCHAR(255)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTOHISTORICO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EVENTOHISTORICO_EVENTO",
                        column: x => x.EVENTO_ID,
                        principalTable: "EVENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVENTOHISTORICO_USUARIO",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PESSOAHISTORICO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PESSOA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DADOSANTES = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true),
                    DADOSDEPOIS = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OBSERVACOES = table.Column<string>(type: "VARCHAR(255)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAHISTORICO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PESSOAHISTORICO_PESSOA",
                        column: x => x.PESSOA_ID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PESSOAHISTORICO_USUARIO",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EVENTOHISTORICO_EVENTO_ID",
                table: "EVENTOHISTORICO",
                column: "EVENTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTOHISTORICO_USUARIO_ID",
                table: "EVENTOHISTORICO",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAHISTORICO_PESSOA_ID",
                table: "PESSOAHISTORICO",
                column: "PESSOA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAHISTORICO_USUARIO_ID",
                table: "PESSOAHISTORICO",
                column: "USUARIO_ID");
        }
    }
}
