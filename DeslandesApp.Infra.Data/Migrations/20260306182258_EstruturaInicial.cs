using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstruturaInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INFORMACOESCOMPLEMENTARES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATANASCIMENTO = table.Column<DateOnly>(type: "date", nullable: false),
                    NOMEEMPRESA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    PROFISSAO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ATIVIDADEECONOMICA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ESTADOCIVIL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CODIGO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NOMEPAI = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NOMEMAE = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NATURALIDADE = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NASCIONALIDADE = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    COMENTARIO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    PESSOA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INFORMACOESCOMPLEMENTARES", x => x.Id);
                });

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
                    NOMESETOR = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
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
                    NOMESEXO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEXO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Apelido = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Site = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATATATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SEXO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdEtiqueta = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ValorEmail = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
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
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    SimplesNacional = table.Column<int>(type: "int", nullable: true),
                    PessoaJuridica_IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PessoaJuridica_PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PESSOA_INFORMACOESCOMPLEMENTARES_Id",
                        column: x => x.Id,
                        principalTable: "INFORMACOESCOMPLEMENTARES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PESSOA_PESSOA_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "PESSOA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PESSOA_PESSOA_PessoaJuridica_PessoaId",
                        column: x => x.PessoaJuridica_PessoaId,
                        principalTable: "PESSOA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PESSOA_SEXO_SEXO_ID",
                        column: x => x.SEXO_ID,
                        principalTable: "SEXO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LOGRADOURO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NUMERO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    BAIRRO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CEP = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    LOCALIDADE = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    UF = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
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
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeUsuario = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    LOGIN = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    SENHA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PESSOA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: true),
                    ValorEmail = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USUARIOS_PESSOA_PESSOA_ID",
                        column: x => x.PESSOA_ID,
                        principalTable: "PESSOA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FOTOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FOTONOME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    FileUrl = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_PESSOA_ID",
                table: "ENDERECO",
                column: "PESSOA_ID",
                unique: true);

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
                name: "IX_PESSOA_PessoaId",
                table: "PESSOA",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_PessoaJuridica_PessoaId",
                table: "PESSOA",
                column: "PessoaJuridica_PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_SEXO_ID",
                table: "PESSOA",
                column: "SEXO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_ValorEmail",
                table: "PESSOA",
                column: "ValorEmail",
                unique: true,
                filter: "[ValorEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SEXO_NOMESEXO",
                table: "SEXO",
                column: "NOMESEXO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_PESSOA_ID",
                table: "USUARIOS",
                column: "PESSOA_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ValorEmail",
                table: "USUARIOS",
                column: "ValorEmail",
                unique: true,
                filter: "[ValorEmail] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "FOTOS");

            migrationBuilder.DropTable(
                name: "GRUPONIVEL");

            migrationBuilder.DropTable(
                name: "GRUPOSETORES");

            migrationBuilder.DropTable(
                name: "NIVEL");

            migrationBuilder.DropTable(
                name: "SETORES");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "PESSOA");

            migrationBuilder.DropTable(
                name: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropTable(
                name: "SEXO");
        }
    }
}
