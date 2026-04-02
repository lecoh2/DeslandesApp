using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventoResponsavelHistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENTORESPONSAVEL_USUARIOS_USUARIOID",
                table: "EVENTORESPONSAVEL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EVENTORESPONSAVEL",
                table: "EVENTORESPONSAVEL");

            migrationBuilder.RenameTable(
                name: "EVENTORESPONSAVEL",
                newName: "GRUPOEVENTORESPONSAVEL");

            migrationBuilder.RenameIndex(
                name: "IX_EVENTORESPONSAVEL_USUARIOID",
                table: "GRUPOEVENTORESPONSAVEL",
                newName: "IX_GRUPOEVENTORESPONSAVEL_USUARIOID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GRUPOEVENTORESPONSAVEL",
                table: "GRUPOEVENTORESPONSAVEL",
                columns: new[] { "EVENTOID", "USUARIOID" });

            migrationBuilder.CreateTable(
                name: "EVENTOHISTORICO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EVENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "VARCHAR(255)", unicode: false, maxLength: 250, nullable: true),
                    DADOSANTES = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true),
                    DADOSDEPOIS = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_EVENTOHISTORICO_EVENTO_ID",
                table: "EVENTOHISTORICO",
                column: "EVENTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTOHISTORICO_USUARIO_ID",
                table: "EVENTOHISTORICO",
                column: "USUARIO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOEVENTORESPONSAVEL_USUARIOS_USUARIOID",
                table: "GRUPOEVENTORESPONSAVEL",
                column: "USUARIOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOEVENTORESPONSAVEL_USUARIOS_USUARIOID",
                table: "GRUPOEVENTORESPONSAVEL");

            migrationBuilder.DropTable(
                name: "EVENTOHISTORICO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GRUPOEVENTORESPONSAVEL",
                table: "GRUPOEVENTORESPONSAVEL");

            migrationBuilder.RenameTable(
                name: "GRUPOEVENTORESPONSAVEL",
                newName: "EVENTORESPONSAVEL");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOEVENTORESPONSAVEL_USUARIOID",
                table: "EVENTORESPONSAVEL",
                newName: "IX_EVENTORESPONSAVEL_USUARIOID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EVENTORESPONSAVEL",
                table: "EVENTORESPONSAVEL",
                columns: new[] { "EVENTOID", "USUARIOID" });

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTORESPONSAVEL_USUARIOS_USUARIOID",
                table: "EVENTORESPONSAVEL",
                column: "USUARIOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
