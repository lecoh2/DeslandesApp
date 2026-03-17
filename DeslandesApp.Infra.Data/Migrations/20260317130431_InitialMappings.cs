using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_SEXO_SEXO_ID",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "TipoTelefone",
                table: "PESSOA");

            migrationBuilder.CreateTable(
                name: "ACAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEACAO = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FORO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEFORO = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PROCESSO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAcao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdForo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Pasta = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Titulo = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    NumeroProcesso = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Juizo = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Vara = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    LinkTribunal = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Objeto = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ValorCausa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Distribuido = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValorCondenacao = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Responsavael = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Etiqueta = table.Column<int>(type: "int", nullable: true),
                    Instancia = table.Column<int>(type: "int", nullable: true),
                    Acesso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCESSO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROCESSO_ACAO_IdAcao",
                        column: x => x.IdAcao,
                        principalTable: "ACAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROCESSO_FORO_IdForo",
                        column: x => x.IdForo,
                        principalTable: "FORO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GRUPOPESSOACLIENTES",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProcesso = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOPESSOACLIENTES", x => new { x.IdPessoa, x.IdProcesso });
                    table.ForeignKey(
                        name: "FK_GRUPOPESSOACLIENTES_PESSOA_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "PESSOA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOPESSOACLIENTES_PROCESSO_IdProcesso",
                        column: x => x.IdProcesso,
                        principalTable: "PROCESSO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PESSOAPROCESSO",
                columns: table => new
                {
                    OutrosEnvolvidosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAPROCESSO", x => new { x.OutrosEnvolvidosId, x.ProcessoId });
                    table.ForeignKey(
                        name: "FK_PESSOAPROCESSO_PESSOA_OutrosEnvolvidosId",
                        column: x => x.OutrosEnvolvidosId,
                        principalTable: "PESSOA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PESSOAPROCESSO_PROCESSO_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "PROCESSO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QUALIFICACAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEQUALIFICACAO = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUALIFICACAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUALIFICACAO_PROCESSO_Id",
                        column: x => x.Id,
                        principalTable: "PROCESSO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOPESSOACLIENTES_IdProcesso",
                table: "GRUPOPESSOACLIENTES",
                column: "IdProcesso");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAPROCESSO_ProcessoId",
                table: "PESSOAPROCESSO",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSO_IdAcao",
                table: "PROCESSO",
                column: "IdAcao");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSO_IdForo",
                table: "PROCESSO",
                column: "IdForo");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_SEXO_SEXO_ID",
                table: "PESSOA",
                column: "SEXO_ID",
                principalTable: "SEXO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_SEXO_SEXO_ID",
                table: "PESSOA");

            migrationBuilder.DropTable(
                name: "GRUPOPESSOACLIENTES");

            migrationBuilder.DropTable(
                name: "PESSOAPROCESSO");

            migrationBuilder.DropTable(
                name: "QUALIFICACAO");

            migrationBuilder.DropTable(
                name: "PROCESSO");

            migrationBuilder.DropTable(
                name: "ACAO");

            migrationBuilder.DropTable(
                name: "FORO");

            migrationBuilder.AddColumn<int>(
                name: "TipoTelefone",
                table: "PESSOA",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_SEXO_SEXO_ID",
                table: "PESSOA",
                column: "SEXO_ID",
                principalTable: "SEXO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
