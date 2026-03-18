using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initaial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEACAO = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACAO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JUIZO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEJUIZO = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JUIZO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NIVEL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMENIVEL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIVEL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QUALIFICACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEQUALIFICACAO = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUALIFICACAO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SETORES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMESETOR = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SETORES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SEXO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMESEXO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEXO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEUSUARIO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    LOGIN = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    SENHA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VARA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEVARA = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    JUIZOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VARA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VARA_JUIZO_JUIZOID",
                        column: x => x.JUIZOID,
                        principalTable: "JUIZO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FOTOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FOTONOME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    FILEURL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FOTOS_USUARIOS_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GRUPONIVEL",
                columns: table => new
                {
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNIVEL = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPONIVEL", x => new { x.IDUSUARIO, x.IDNIVEL });
                    table.ForeignKey(
                        name: "FK_GRUPONIVEL_NIVEL_IDNIVEL",
                        column: x => x.IDNIVEL,
                        principalTable: "NIVEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GRUPONIVEL_USUARIOS_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GRUPOSETORES",
                columns: table => new
                {
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSETOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOSETORES", x => new { x.IDUSUARIO, x.IDSETOR });
                    table.ForeignKey(
                        name: "FK_GRUPOSETORES_SETORES_IDSETOR",
                        column: x => x.IDSETOR,
                        principalTable: "SETORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GRUPOSETORES_USUARIOS_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOGINHISTORY",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IPACESSO = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    USERAGENT = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    DATAHORAACESSO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SUCESSO = table.Column<bool>(type: "bit", nullable: false),
                    MENSAGEM = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGINHISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOGINHISTORY_USUARIOS_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    APELIDO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    TELEFONE = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    SITE = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SEXO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ETIQUETA = table.Column<int>(type: "int", nullable: true),
                    PERFIL = table.Column<int>(type: "int", nullable: true),
                    TIPOEMAIL = table.Column<int>(type: "int", nullable: true),
                    TIPO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    RG = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CPF = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    TITULOELEITOR = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CARTEIRATRABALHO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PISPASEP = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CNH = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PASSAPORTE = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CERTIDAORESERVISTA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    INSCRICAOESTADUAL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    INSCRICAOMUNICIPAL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    SIMPLESNACIONAL = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PESSOA_SEXO_SEXO_ID",
                        column: x => x.SEXO_ID,
                        principalTable: "SEXO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PESSOA_USUARIOS_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FORO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEFORO = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    VARAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FORO_VARA_VARAID",
                        column: x => x.VARAID,
                        principalTable: "VARA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ENDERECO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ENDERECO_PESSOA_PESSOA_ID",
                        column: x => x.PESSOA_ID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INFORMACOESCOMPLEMENTARES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CODIGO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMENTARIO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PESSOA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TIPOPESSOA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATANASCIMENTO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    NOMEEMPRESA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
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
                    table.PrimaryKey("PK_INFORMACOESCOMPLEMENTARES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INFORMACOESCOMPLEMENTARES_PESSOA_PESSOA_ID",
                        column: x => x.PESSOA_ID,
                        principalTable: "PESSOA",
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
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OBSERVACOES = table.Column<string>(type: "VARCHAR(255)", unicode: false, maxLength: 250, nullable: true),
                    DADOSANTES = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true),
                    DADOSDEPOIS = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "PROCESSOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FOROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PASTA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    TITULO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    NUMEROPROCESSO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    LINKTRIBUNAL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    OBJETO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    VALORCAUSA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DISTRIBUIDO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALORCONDENACAO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    RESPONSAVAEL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ETIQUETA = table.Column<int>(type: "int", nullable: true),
                    INSTANCIA = table.Column<int>(type: "int", nullable: true),
                    ACESSO = table.Column<int>(type: "int", nullable: true),
                    FOROID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCESSOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PROCESSOS_ACAO_ACAOID",
                        column: x => x.ACAOID,
                        principalTable: "ACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROCESSOS_FORO_FOROID",
                        column: x => x.FOROID,
                        principalTable: "FORO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROCESSOS_FORO_FOROID1",
                        column: x => x.FOROID1,
                        principalTable: "FORO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GRUPOENVOLVIDOS",
                columns: table => new
                {
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUALIFICACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOENVOLVIDOS", x => new { x.PESSOAID, x.PROCESSOID, x.QUALIFICACAOID });
                    table.ForeignKey(
                        name: "FK_GRUPOENVOLVIDOS_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOENVOLVIDOS_PROCESSOS_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOENVOLVIDOS_QUALIFICACAO_QUALIFICACAOID",
                        column: x => x.QUALIFICACAOID,
                        principalTable: "QUALIFICACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GRUPOPESSOACLIENTES",
                columns: table => new
                {
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUALIFICACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOPESSOACLIENTES", x => new { x.PESSOAID, x.PROCESSOID, x.QUALIFICACAOID });
                    table.ForeignKey(
                        name: "FK_GRUPOPESSOACLIENTES_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOPESSOACLIENTES_PROCESSOS_PROCESSOID",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPOPESSOACLIENTES_QUALIFICACAO_QUALIFICACAOID",
                        column: x => x.QUALIFICACAOID,
                        principalTable: "QUALIFICACAO",
                        principalColumn: "ID",
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
                name: "IX_FORO_VARAID",
                table: "FORO",
                column: "VARAID");

            migrationBuilder.CreateIndex(
                name: "IX_FOTOS_USUARIO_ID",
                table: "FOTOS",
                column: "USUARIO_ID",
                unique: true,
                filter: "[USUARIO_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOENVOLVIDOS_PROCESSOID",
                table: "GRUPOENVOLVIDOS",
                column: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOENVOLVIDOS_QUALIFICACAOID",
                table: "GRUPOENVOLVIDOS",
                column: "QUALIFICACAOID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPONIVEL_IDNIVEL",
                table: "GRUPONIVEL",
                column: "IDNIVEL");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOPESSOACLIENTES_PROCESSOID",
                table: "GRUPOPESSOACLIENTES",
                column: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOPESSOACLIENTES_QUALIFICACAOID",
                table: "GRUPOPESSOACLIENTES",
                column: "QUALIFICACAOID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOSETORES_IDSETOR",
                table: "GRUPOSETORES",
                column: "IDSETOR");

            migrationBuilder.CreateIndex(
                name: "IX_INFORMACOESCOMPLEMENTARES_PESSOA_ID",
                table: "INFORMACOESCOMPLEMENTARES",
                column: "PESSOA_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LOGINHISTORY_IDUSUARIO",
                table: "LOGINHISTORY",
                column: "IDUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_SEXO_ID",
                table: "PESSOA",
                column: "SEXO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_USUARIO_ID",
                table: "PESSOA",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAHISTORICO_PESSOA_ID",
                table: "PESSOAHISTORICO",
                column: "PESSOA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAHISTORICO_USUARIO_ID",
                table: "PESSOAHISTORICO",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_ACAOID",
                table: "PROCESSOS",
                column: "ACAOID");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_FOROID",
                table: "PROCESSOS",
                column: "FOROID");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_FOROID1",
                table: "PROCESSOS",
                column: "FOROID1");

            migrationBuilder.CreateIndex(
                name: "IX_SEXO_NOMESEXO",
                table: "SEXO",
                column: "NOMESEXO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VARA_JUIZOID",
                table: "VARA",
                column: "JUIZOID");
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
                name: "GRUPOENVOLVIDOS");

            migrationBuilder.DropTable(
                name: "GRUPONIVEL");

            migrationBuilder.DropTable(
                name: "GRUPOPESSOACLIENTES");

            migrationBuilder.DropTable(
                name: "GRUPOSETORES");

            migrationBuilder.DropTable(
                name: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropTable(
                name: "LOGINHISTORY");

            migrationBuilder.DropTable(
                name: "PESSOAHISTORICO");

            migrationBuilder.DropTable(
                name: "NIVEL");

            migrationBuilder.DropTable(
                name: "PROCESSOS");

            migrationBuilder.DropTable(
                name: "QUALIFICACAO");

            migrationBuilder.DropTable(
                name: "SETORES");

            migrationBuilder.DropTable(
                name: "PESSOA");

            migrationBuilder.DropTable(
                name: "ACAO");

            migrationBuilder.DropTable(
                name: "FORO");

            migrationBuilder.DropTable(
                name: "SEXO");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "VARA");

            migrationBuilder.DropTable(
                name: "JUIZO");
        }
    }
}
