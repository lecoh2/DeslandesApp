using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoDosRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QUALIFICACAO_PROCESSO_ID",
                table: "QUALIFICACAO");

            migrationBuilder.DropTable(
                name: "PESSOAPROCESSO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GRUPOPESSOACLIENTES",
                table: "GRUPOPESSOACLIENTES");

            migrationBuilder.AddColumn<Guid>(
                name: "IDQUALIFICACAO",
                table: "GRUPOPESSOACLIENTES",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GRUPOPESSOACLIENTES",
                table: "GRUPOPESSOACLIENTES",
                columns: new[] { "IDPESSOA", "IDPROCESSO", "IDQUALIFICACAO" });

            migrationBuilder.CreateTable(
                name: "GRUPOENVOLVIDOS",
                columns: table => new
                {
                    IDPESSOA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDPROCESSO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDQUALIFICACAO = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOENVOLVIDOS", x => new { x.IDPESSOA, x.IDPROCESSO, x.IDQUALIFICACAO });
                    table.ForeignKey(
                        name: "FK_GRUPOENVOLVIDOS_PESSOA_IDPESSOA",
                        column: x => x.IDPESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOENVOLVIDOS_PROCESSO_IDPROCESSO",
                        column: x => x.IDPROCESSO,
                        principalTable: "PROCESSO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOENVOLVIDOS_QUALIFICACAO_IDQUALIFICACAO",
                        column: x => x.IDQUALIFICACAO,
                        principalTable: "QUALIFICACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOPESSOACLIENTES_IDQUALIFICACAO",
                table: "GRUPOPESSOACLIENTES",
                column: "IDQUALIFICACAO");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOENVOLVIDOS_IDPROCESSO",
                table: "GRUPOENVOLVIDOS",
                column: "IDPROCESSO");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOENVOLVIDOS_IDQUALIFICACAO",
                table: "GRUPOENVOLVIDOS",
                column: "IDQUALIFICACAO");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_QUALIFICACAO_IDQUALIFICACAO",
                table: "GRUPOPESSOACLIENTES",
                column: "IDQUALIFICACAO",
                principalTable: "QUALIFICACAO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOPESSOACLIENTES_QUALIFICACAO_IDQUALIFICACAO",
                table: "GRUPOPESSOACLIENTES");

            migrationBuilder.DropTable(
                name: "GRUPOENVOLVIDOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GRUPOPESSOACLIENTES",
                table: "GRUPOPESSOACLIENTES");

            migrationBuilder.DropIndex(
                name: "IX_GRUPOPESSOACLIENTES_IDQUALIFICACAO",
                table: "GRUPOPESSOACLIENTES");

            migrationBuilder.DropColumn(
                name: "IDQUALIFICACAO",
                table: "GRUPOPESSOACLIENTES");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GRUPOPESSOACLIENTES",
                table: "GRUPOPESSOACLIENTES",
                columns: new[] { "IDPESSOA", "IDPROCESSO" });

            migrationBuilder.CreateTable(
                name: "PESSOAPROCESSO",
                columns: table => new
                {
                    OUTROSENVOLVIDOSID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAPROCESSO", x => new { x.OUTROSENVOLVIDOSID, x.PROCESSOID });
                    table.ForeignKey(
                        name: "FK_PESSOAPROCESSO_PESSOA_OUTROSENVOLVIDOSID",
                        column: x => x.OUTROSENVOLVIDOSID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PESSOAPROCESSO_PROCESSO_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAPROCESSO_PROCESSOID",
                table: "PESSOAPROCESSO",
                column: "PROCESSOID");

            migrationBuilder.AddForeignKey(
                name: "FK_QUALIFICACAO_PROCESSO_ID",
                table: "QUALIFICACAO",
                column: "ID",
                principalTable: "PROCESSO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
