using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CasoEventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATENDIMENTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ASSUNTO = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    REGISTRO = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    ETIQUETA = table.Column<int>(type: "int", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATENDIMENTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ATENDIMENTO_PROCESSO",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CASO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PASTA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    TITULO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    OBSERVACAO = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    RESPONSAVELID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ACESSO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CASO_PESSOA",
                        column: x => x.RESPONSAVELID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EVENTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TITULO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATAINICIAL = table.Column<DateOnly>(type: "date", nullable: false),
                    HORAINICIAL = table.Column<TimeOnly>(type: "time", nullable: false),
                    DATAFINAL = table.Column<DateOnly>(type: "date", nullable: true),
                    HORAFINAL = table.Column<TimeOnly>(type: "time", nullable: true),
                    DIAINTEIRO = table.Column<bool>(type: "bit", nullable: false),
                    ENDERECO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    MODALIDADE = table.Column<int>(type: "int", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    ENTIDADEID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TIPOVINCULO = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ATENDIMENTCLIENTE",
                columns: table => new
                {
                    ATENDIMENTOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATENDIMENTCLIENTE", x => new { x.ATENDIMENTOID, x.PESSOAID });
                    table.ForeignKey(
                        name: "FK_ATENDIMENTCLIENTE_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ATENDIMENTO_ATENDIMENTCLIENTE",
                        column: x => x.ATENDIMENTOID,
                        principalTable: "ATENDIMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GRUPOCASOCLIENTE",
                columns: table => new
                {
                    CASOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOCASOCLIENTE", x => new { x.CASOID, x.PESSOAID });
                    table.ForeignKey(
                        name: "FK_CASO_CASOCLIENTE",
                        column: x => x.CASOID,
                        principalTable: "CASO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOCASOCLIENTE_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GRUPOCASOENVOLVIDO",
                columns: table => new
                {
                    CASOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUALIFICACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOCASOENVOLVIDO", x => new { x.CASOID, x.PESSOAID });
                    table.ForeignKey(
                        name: "FK_CASO_CASOENVOLVIDO",
                        column: x => x.CASOID,
                        principalTable: "CASO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOCASOENVOLVIDO_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GRUPOCASOENVOLVIDO_QUALIFICACAO_QUALIFICACAOID",
                        column: x => x.QUALIFICACAOID,
                        principalTable: "QUALIFICACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EVENTORESPONSAVEL",
                columns: table => new
                {
                    EVENTOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTORESPONSAVEL", x => new { x.EVENTOID, x.PESSOAID });
                    table.ForeignKey(
                        name: "FK_EVENTORESPONSAVEL_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVENTO_EVENTORESPONSAVEL",
                        column: x => x.EVENTOID,
                        principalTable: "EVENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTCLIENTE_PESSOAID",
                table: "ATENDIMENTCLIENTE",
                column: "PESSOAID");

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTO_PROCESSOID",
                table: "ATENDIMENTO",
                column: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_CASO_RESPONSAVELID",
                table: "CASO",
                column: "RESPONSAVELID");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTORESPONSAVEL_PESSOAID",
                table: "EVENTORESPONSAVEL",
                column: "PESSOAID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOCASOCLIENTE_PESSOAID",
                table: "GRUPOCASOCLIENTE",
                column: "PESSOAID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOCASOENVOLVIDO_PESSOAID",
                table: "GRUPOCASOENVOLVIDO",
                column: "PESSOAID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOCASOENVOLVIDO_QUALIFICACAOID",
                table: "GRUPOCASOENVOLVIDO",
                column: "QUALIFICACAOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATENDIMENTCLIENTE");

            migrationBuilder.DropTable(
                name: "EVENTORESPONSAVEL");

            migrationBuilder.DropTable(
                name: "GRUPOCASOCLIENTE");

            migrationBuilder.DropTable(
                name: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropTable(
                name: "ATENDIMENTO");

            migrationBuilder.DropTable(
                name: "EVENTO");

            migrationBuilder.DropTable(
                name: "CASO");
        }
    }
}
