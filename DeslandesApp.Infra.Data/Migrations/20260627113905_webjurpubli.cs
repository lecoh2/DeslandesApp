using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class webjurpubli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WEBJURARQUIVO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WEBJURPUBLICACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEARQUIVO = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    CAMINHOARQUIVO = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    TIPOARQUIVO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOATUALIZACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBJURARQUIVO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WEBJURARQUIVO_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WEBJURARQUIVO_WEBJURPUBLICACAO_WEBJURPUBLICACAOID",
                        column: x => x.WEBJURPUBLICACAOID,
                        principalTable: "WEBJURPUBLICACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WEBJURCOMENTARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WEBJURPUBLICACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COMENTARIO = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOATUALIZACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBJURCOMENTARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WEBJURCOMENTARIO_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WEBJURCOMENTARIO_USUARIOS_USUARIOID",
                        column: x => x.USUARIOID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WEBJURCOMENTARIO_WEBJURPUBLICACAO_WEBJURPUBLICACAOID",
                        column: x => x.WEBJURPUBLICACAOID,
                        principalTable: "WEBJURPUBLICACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WEBJURMOVIMENTACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WEBJURPUBLICACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATAMOVIMENTACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TIPO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: false),
                    ORIGEM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOATUALIZACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBJURMOVIMENTACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WEBJURMOVIMENTACAO_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WEBJURMOVIMENTACAO_WEBJURPUBLICACAO_WEBJURPUBLICACAOID",
                        column: x => x.WEBJURPUBLICACAOID,
                        principalTable: "WEBJURPUBLICACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WEBJURSINCRONIZACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WEBJURPUBLICACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    INICIO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FIM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SUCESSO = table.Column<bool>(type: "bit", nullable: false),
                    MENSAGEM = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    USUARIOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOATUALIZACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBJURSINCRONIZACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WEBJURSINCRONIZACAO_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WEBJURSINCRONIZACAO_USUARIOS_USUARIOID",
                        column: x => x.USUARIOID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WEBJURSINCRONIZACAO_WEBJURPUBLICACAO_WEBJURPUBLICACAOID",
                        column: x => x.WEBJURPUBLICACAOID,
                        principalTable: "WEBJURPUBLICACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WEBJURVISUALIZACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WEBJURPUBLICACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATAVISUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOATUALIZACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBJURVISUALIZACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WEBJURVISUALIZACAO_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WEBJURVISUALIZACAO_USUARIOS_USUARIOID",
                        column: x => x.USUARIOID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WEBJURVISUALIZACAO_WEBJURPUBLICACAO_WEBJURPUBLICACAOID",
                        column: x => x.WEBJURPUBLICACAOID,
                        principalTable: "WEBJURPUBLICACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURARQUIVO_USUARIOCADASTROID",
                table: "WEBJURARQUIVO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURARQUIVO_WEBJURPUBLICACAOID",
                table: "WEBJURARQUIVO",
                column: "WEBJURPUBLICACAOID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURCOMENTARIO_USUARIOCADASTROID",
                table: "WEBJURCOMENTARIO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURCOMENTARIO_USUARIOID",
                table: "WEBJURCOMENTARIO",
                column: "USUARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURCOMENTARIO_WEBJURPUBLICACAOID",
                table: "WEBJURCOMENTARIO",
                column: "WEBJURPUBLICACAOID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURMOVIMENTACAO_USUARIOCADASTROID",
                table: "WEBJURMOVIMENTACAO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURMOVIMENTACAO_WEBJURPUBLICACAOID",
                table: "WEBJURMOVIMENTACAO",
                column: "WEBJURPUBLICACAOID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURSINCRONIZACAO_USUARIOCADASTROID",
                table: "WEBJURSINCRONIZACAO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURSINCRONIZACAO_USUARIOID",
                table: "WEBJURSINCRONIZACAO",
                column: "USUARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURSINCRONIZACAO_WEBJURPUBLICACAOID",
                table: "WEBJURSINCRONIZACAO",
                column: "WEBJURPUBLICACAOID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURVISUALIZACAO_USUARIOCADASTROID",
                table: "WEBJURVISUALIZACAO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURVISUALIZACAO_USUARIOID",
                table: "WEBJURVISUALIZACAO",
                column: "USUARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURVISUALIZACAO_WEBJURPUBLICACAOID",
                table: "WEBJURVISUALIZACAO",
                column: "WEBJURPUBLICACAOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WEBJURARQUIVO");

            migrationBuilder.DropTable(
                name: "WEBJURCOMENTARIO");

            migrationBuilder.DropTable(
                name: "WEBJURMOVIMENTACAO");

            migrationBuilder.DropTable(
                name: "WEBJURSINCRONIZACAO");

            migrationBuilder.DropTable(
                name: "WEBJURVISUALIZACAO");
        }
    }
}
