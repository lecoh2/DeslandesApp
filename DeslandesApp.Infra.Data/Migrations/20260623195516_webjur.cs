using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class webjur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOCADASTROID",
                table: "PROCESSOS");

            migrationBuilder.AddColumn<Guid>(
                name: "ACESSOID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CLASSEPROCESSUALID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ERROULTIMACONSULTA",
                table: "PROCESSOS",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "INSTANCIAID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MONITORARANDAMENTOS",
                table: "PROCESSOS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SITUACAO",
                table: "PROCESSOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TRIBUNALID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ULTIMACONSULTATRIBUNAL",
                table: "PROCESSOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ULTIMOANDAMENTOCAPTURADO",
                table: "PROCESSOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ANDAMENTOSPROCESSO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATAMOVIMENTACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ORIGEM = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CAPTURADOAUTOMATICAMENTE = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ANDAMENTOSPROCESSO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ANDAMENTOSPROCESSO_PROCESSOS_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ANDAMENTOSPROCESSO_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AUDIENCIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATAHORA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    LOCAL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    LINKVIDEOCONFERENCIA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    MAGISTRADO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    OBSERVACAO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    RESULTADO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
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
                    table.PrimaryKey("PK_AUDIENCIA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AUDIENCIA_PROCESSOS_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AUDIENCIA_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CLASSEPROCESSUAL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_CLASSEPROCESSUAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLASSEPROCESSUAL_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PRAZOPROCESSUAL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATAVENCIMENTO = table.Column<DateOnly>(type: "date", nullable: false),
                    CONCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    RESPONSAVELID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_PRAZOPROCESSUAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRAZOPROCESSUAL_PROCESSOS_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRAZOPROCESSUAL_USUARIOS_RESPONSAVELID",
                        column: x => x.RESPONSAVELID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRAZOPROCESSUAL_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TRIBUNAL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_TRIBUNAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRIBUNAL_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_CLASSEPROCESSUALID",
                table: "PROCESSOS",
                column: "CLASSEPROCESSUALID");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_TRIBUNALID",
                table: "PROCESSOS",
                column: "TRIBUNALID");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_USUARIOATUALIZACAOID",
                table: "PROCESSOS",
                column: "USUARIOATUALIZACAOID");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_USUARIOEXCLUSAOID",
                table: "PROCESSOS",
                column: "USUARIOEXCLUSAOID");

            migrationBuilder.CreateIndex(
                name: "IX_ANDAMENTOSPROCESSO_PROCESSOID",
                table: "ANDAMENTOSPROCESSO",
                column: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_ANDAMENTOSPROCESSO_USUARIOCADASTROID",
                table: "ANDAMENTOSPROCESSO",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_AUDIENCIA_PROCESSOID",
                table: "AUDIENCIA",
                column: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_AUDIENCIA_USUARIOCADASTROID",
                table: "AUDIENCIA",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_CLASSEPROCESSUAL_USUARIOCADASTROID",
                table: "CLASSEPROCESSUAL",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_PRAZOPROCESSUAL_PROCESSOID",
                table: "PRAZOPROCESSUAL",
                column: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_PRAZOPROCESSUAL_RESPONSAVELID",
                table: "PRAZOPROCESSUAL",
                column: "RESPONSAVELID");

            migrationBuilder.CreateIndex(
                name: "IX_PRAZOPROCESSUAL_USUARIOCADASTROID",
                table: "PRAZOPROCESSUAL",
                column: "USUARIOCADASTROID");

            migrationBuilder.CreateIndex(
                name: "IX_TRIBUNAL_USUARIOCADASTROID",
                table: "TRIBUNAL",
                column: "USUARIOCADASTROID");

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_CLASSEPROCESSUAL_CLASSEPROCESSUALID",
                table: "PROCESSOS",
                column: "CLASSEPROCESSUALID",
                principalTable: "CLASSEPROCESSUAL",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_TRIBUNAL_TRIBUNALID",
                table: "PROCESSOS",
                column: "TRIBUNALID",
                principalTable: "TRIBUNAL",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOATUALIZACAOID",
                table: "PROCESSOS",
                column: "USUARIOATUALIZACAOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOCADASTROID",
                table: "PROCESSOS",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOEXCLUSAOID",
                table: "PROCESSOS",
                column: "USUARIOEXCLUSAOID",
                principalTable: "USUARIOS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_CLASSEPROCESSUAL_CLASSEPROCESSUALID",
                table: "PROCESSOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_TRIBUNAL_TRIBUNALID",
                table: "PROCESSOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOATUALIZACAOID",
                table: "PROCESSOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOCADASTROID",
                table: "PROCESSOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOEXCLUSAOID",
                table: "PROCESSOS");

            migrationBuilder.DropTable(
                name: "ANDAMENTOSPROCESSO");

            migrationBuilder.DropTable(
                name: "AUDIENCIA");

            migrationBuilder.DropTable(
                name: "CLASSEPROCESSUAL");

            migrationBuilder.DropTable(
                name: "PRAZOPROCESSUAL");

            migrationBuilder.DropTable(
                name: "TRIBUNAL");

            migrationBuilder.DropIndex(
                name: "IX_PROCESSOS_CLASSEPROCESSUALID",
                table: "PROCESSOS");

            migrationBuilder.DropIndex(
                name: "IX_PROCESSOS_TRIBUNALID",
                table: "PROCESSOS");

            migrationBuilder.DropIndex(
                name: "IX_PROCESSOS_USUARIOATUALIZACAOID",
                table: "PROCESSOS");

            migrationBuilder.DropIndex(
                name: "IX_PROCESSOS_USUARIOEXCLUSAOID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "ACESSOID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "CLASSEPROCESSUALID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "ERROULTIMACONSULTA",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "INSTANCIAID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "MONITORARANDAMENTOS",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "SITUACAO",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "TRIBUNALID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "ULTIMACONSULTATRIBUNAL",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "ULTIMOANDAMENTOCAPTURADO",
                table: "PROCESSOS");

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_USUARIOS_USUARIOCADASTROID",
                table: "PROCESSOS",
                column: "USUARIOCADASTROID",
                principalTable: "USUARIOS",
                principalColumn: "ID");
        }
    }
}
