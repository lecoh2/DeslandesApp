using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateWebJurPublicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WEBJURPUBLICACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CODPUBLICACAO = table.Column<int>(type: "int", nullable: false),
                    NUMEROPROCESSO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DATAPUBLICACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATACADASTROWEBJUR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DESPACHOPUBLICACAO = table.Column<string>(type: "nvarchar(max)", unicode: false, maxLength: 250, nullable: true),
                    PROCESSOPUBLICACAO = table.Column<string>(type: "nvarchar(max)", unicode: false, maxLength: 250, nullable: true),
                    VARADESCRICAO = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ORGAODESCRICAO = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PUBLICACAOCORRIGIDA = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IMPORTADA = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PROCESSOID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_WEBJURPUBLICACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WEBJURPUBLICACAO_PROCESSOS_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WEBJURPUBLICACAO_PROCESSOS_PROCESSOID1",
                        column: x => x.PROCESSOID1,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WEBJURPUBLICACAO_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURPUBLICACAO_CODPUBLICACAO",
                table: "WEBJURPUBLICACAO",
                column: "CODPUBLICACAO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURPUBLICACAO_PROCESSOID",
                table: "WEBJURPUBLICACAO",
                column: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURPUBLICACAO_PROCESSOID1",
                table: "WEBJURPUBLICACAO",
                column: "PROCESSOID1");

            migrationBuilder.CreateIndex(
                name: "IX_WEBJURPUBLICACAO_USUARIOCADASTROID",
                table: "WEBJURPUBLICACAO",
                column: "USUARIOCADASTROID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WEBJURPUBLICACAO");
        }
    }
}
