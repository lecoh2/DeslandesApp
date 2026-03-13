using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NIVEL",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMENIVEL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIVEL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SETORES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMESETOR = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SETORES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SEXO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMESEXO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEXO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeUsuario = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    LOGIN = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    SENHA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAILEDLOGINATTEMPTS",
                columns: table => new
                {
                    IDFAILEDLOGINATTEMPT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LOGIN = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    IPACESSO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    USERAGENT = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    DATAHORA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MENSAGEM = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAILEDLOGINATTEMPTS", x => x.IDFAILEDLOGINATTEMPT);
                    table.ForeignKey(
                        name: "FK_FAILEDLOGINATTEMPTS_USUARIOS_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FOTOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FOTONOME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    FileUrl = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FOTOS_USUARIOS_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRUPONIVEL",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNivel = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPONIVEL", x => new { x.IdUsuario, x.IdNivel });
                    table.ForeignKey(
                        name: "FK_GRUPONIVEL_NIVEL_IdNivel",
                        column: x => x.IdNivel,
                        principalTable: "NIVEL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GRUPONIVEL_USUARIOS_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GRUPOSETORES",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSetor = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOSETORES", x => new { x.IdUsuario, x.IdSetor });
                    table.ForeignKey(
                        name: "FK_GRUPOSETORES_SETORES_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "SETORES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GRUPOSETORES_USUARIOS_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOGINHISTORY",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IPACESSO = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    USERAGENT = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    DataHoraAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sucesso = table.Column<bool>(type: "bit", nullable: false),
                    MENSAGEM = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGINHISTORY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOGINHISTORY_USUARIOS_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    APELIDO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Site = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SEXO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Etiqueta = table.Column<int>(type: "int", nullable: true),
                    Perfil = table.Column<int>(type: "int", nullable: true),
                    TipoTelefone = table.Column<int>(type: "int", nullable: true),
                    TipoEmail = table.Column<int>(type: "int", nullable: true),
                    TIPO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    RG = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CPF = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    TituloEleitor = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CarteiraTrabalho = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PisPasep = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CNH = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Passaporte = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CertidaoReservista = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    SimplesNacional = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PESSOA_SEXO_SEXO_ID",
                        column: x => x.SEXO_ID,
                        principalTable: "SEXO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PESSOA_USUARIOS_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LOGRADOURO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    NUMERO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    COMPLEMENTO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    BAIRRO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CEP = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    LOCALIDADE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    PESSOA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ENDERECO_PESSOA_PESSOA_ID",
                        column: x => x.PESSOA_ID,
                        principalTable: "PESSOA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INFORMACOESCOMPLEMENTARES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CODIGO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMENTARIO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TIPOPESSOA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATANASCIMENTO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    NomeEmpresa = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PROFISSAO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ATIVIDADEECONOMICA = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ESTADOCIVIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NOMEPAI = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    NOMEMAE = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    NATURALIDADE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NACIONALIDADE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CONTATO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CARGO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    NOMEBANCO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    AGENCIA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NUMEROCONTA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PIX = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TIPOCONTA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INFORMACOESCOMPLEMENTARES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INFORMACOESCOMPLEMENTARES_PESSOA_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "PESSOA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_PESSOA_ID",
                table: "ENDERECO",
                column: "PESSOA_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FAILEDLOGINATTEMPTS_IDUSUARIO",
                table: "FAILEDLOGINATTEMPTS",
                column: "IDUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_FOTOS_USUARIO_ID",
                table: "FOTOS",
                column: "USUARIO_ID",
                unique: true,
                filter: "[USUARIO_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPONIVEL_IdNivel",
                table: "GRUPONIVEL",
                column: "IdNivel");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOSETORES_IdSetor",
                table: "GRUPOSETORES",
                column: "IdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_INFORMACOESCOMPLEMENTARES_IdPessoa",
                table: "INFORMACOESCOMPLEMENTARES",
                column: "IdPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LOGINHISTORY_IdUsuario",
                table: "LOGINHISTORY",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_SEXO_ID",
                table: "PESSOA",
                column: "SEXO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_USUARIO_ID",
                table: "PESSOA",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SEXO_NOMESEXO",
                table: "SEXO",
                column: "NOMESEXO",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropTable(
                name: "FOTOS");

            migrationBuilder.DropTable(
                name: "GRUPONIVEL");

            migrationBuilder.DropTable(
                name: "GRUPOSETORES");

            migrationBuilder.DropTable(
                name: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropTable(
                name: "LOGINHISTORY");

            migrationBuilder.DropTable(
                name: "NIVEL");

            migrationBuilder.DropTable(
                name: "SETORES");

            migrationBuilder.DropTable(
                name: "PESSOA");

            migrationBuilder.DropTable(
                name: "SEXO");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
