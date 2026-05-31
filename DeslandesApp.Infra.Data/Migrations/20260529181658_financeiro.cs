using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class financeiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "VARA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "VARA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "VARA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "VARA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "VARA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "VARA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "USUARIOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "USUARIOS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "USUARIOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "USUARIOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "TAREFA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "TAREFA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "SETORES",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "SETORES",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "SETORES",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "SETORES",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "SETORES",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "SETORES",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "QUALIFICACAO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "QUALIFICACAO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "QUALIFICACAO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "QUALIFICACAO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "QUALIFICACAO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "QUALIFICACAO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "PROCESSOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "PROCESSOS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "PESSOA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "PESSOA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "NIVEL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "NIVEL",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "NIVEL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "NIVEL",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "NIVEL",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "NIVEL",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "LOGINHISTORY",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "LOGINHISTORY",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "LOGINHISTORY",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "LOGINHISTORY",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "LOGINHISTORY",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "LOGINHISTORY",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "LISTATAREFA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "LISTATAREFA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "LISTATAREFA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "LISTATAREFA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "LISTATAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "LISTATAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "HISTORICOGERAL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "HISTORICOGERAL",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "HISTORICOGERAL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "HISTORICOGERAL",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "HISTORICOGERAL",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "HISTORICOGERAL",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "GRUPOCASOENVOLVIDO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "GRUPOCASOENVOLVIDO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "GRUPOCASOENVOLVIDO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "GRUPOCASOENVOLVIDO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "GRUPOCASOENVOLVIDO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "GRUPOCASOENVOLVIDO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "FOTOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "FOTOS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "FOTOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "FOTOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "FORO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "FORO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "FORO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "FORO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "FORO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "FORO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "FAILEDLOGINATTEMPTS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "FAILEDLOGINATTEMPTS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "FAILEDLOGINATTEMPTS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "FAILEDLOGINATTEMPTS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "FAILEDLOGINATTEMPTS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "FAILEDLOGINATTEMPTS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "EVENTO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "EVENTO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "EVENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "EVENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "ETIQUETA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "ETIQUETA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "ETIQUETA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "ETIQUETA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "ETIQUETA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "ETIQUETA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "ENDERECO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "ENDERECO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "ENDERECO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "ENDERECO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "ENDERECO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "ENDERECO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "CONTABANCARIA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "CONTABANCARIA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "CONTABANCARIA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "CONTABANCARIA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "CONTABANCARIA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "CONTABANCARIA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "COMENTARIOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "COMENTARIOS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "COMENTARIOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "COMENTARIOS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "COMENTARIOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "COMENTARIOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "CASO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "CASO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "CASO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "ATENDIMENTOHISTORICO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "ATENDIMENTOHISTORICO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "ATENDIMENTOHISTORICO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "ATENDIMENTOHISTORICO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "ATENDIMENTOHISTORICO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "ATENDIMENTOHISTORICO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "ATENDIMENTO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "ATENDIMENTO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "ATENDIMENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAATUALIZACAO",
                table: "ACAO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACADASTRO",
                table: "ACAO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAEXCLUSAO",
                table: "ACAO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EXCLUIDO",
                table: "ACAO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOCADASTROID",
                table: "ACAO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOEXCLUSAOID",
                table: "ACAO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CATEGORIA_FINANCEIRA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA_FINANCEIRA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CENTRO_CUSTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CENTRO_CUSTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTABANCARIAEMPRESA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BANCO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    AGENCIA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CONTA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DIGITO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    SALDOINICIAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ATIVA = table.Column<bool>(type: "bit", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTABANCARIAEMPRESA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTRATO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NUMERO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OBJETO = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DATA_INICIO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATA_FIM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALOR_TOTAL = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTRATO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTRATO_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FORMA_PAGAMENTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMA_PAGAMENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTA_PAGAR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    VALORPAGO = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DATAVENCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CONTRATOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CATEGORIAFINANCEIRAID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CENTROCUSTOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_PAGAR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTA_PAGAR_CATEGORIA_FINANCEIRA_CATEGORIAFINANCEIRAID",
                        column: x => x.CATEGORIAFINANCEIRAID,
                        principalTable: "CATEGORIA_FINANCEIRA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONTA_PAGAR_CENTRO_CUSTO_CENTROCUSTOID",
                        column: x => x.CENTROCUSTOID,
                        principalTable: "CENTRO_CUSTO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CONTA_PAGAR_CONTRATO_CONTRATOID",
                        column: x => x.CONTRATOID,
                        principalTable: "CONTRATO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONTA_PAGAR_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONTA_RECEBER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CONTRATOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DATAEMISSAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATA_VENCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    DATABAIXA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALOR_PAGO = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CATEGORIAFINANCEIRAID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CENTROCUSTOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_RECEBER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTA_RECEBER_CATEGORIA_FINANCEIRA_CATEGORIAFINANCEIRAID",
                        column: x => x.CATEGORIAFINANCEIRAID,
                        principalTable: "CATEGORIA_FINANCEIRA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONTA_RECEBER_CENTRO_CUSTO_CENTROCUSTOID",
                        column: x => x.CENTROCUSTOID,
                        principalTable: "CENTRO_CUSTO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CONTA_RECEBER_CONTRATO_CONTRATOID",
                        column: x => x.CONTRATOID,
                        principalTable: "CONTRATO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONTA_RECEBER_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BAIXA_FINANCEIRA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALORPAGO = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DATABAIXA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CONTARECEBERID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CONTAPAGARID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FORMAPAGAMENTOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CONTABANCARIAEMPRESAID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CONTARECEBERID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAIXA_FINANCEIRA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BAIXA_FINANCEIRA_CONTABANCARIAEMPRESA_CONTABANCARIAEMPRESAID",
                        column: x => x.CONTABANCARIAEMPRESAID,
                        principalTable: "CONTABANCARIAEMPRESA",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BAIXA_FINANCEIRA_CONTA_PAGAR_CONTAPAGARID",
                        column: x => x.CONTAPAGARID,
                        principalTable: "CONTA_PAGAR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BAIXA_FINANCEIRA_CONTA_RECEBER_CONTARECEBERID",
                        column: x => x.CONTARECEBERID,
                        principalTable: "CONTA_RECEBER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BAIXA_FINANCEIRA_CONTA_RECEBER_CONTARECEBERID1",
                        column: x => x.CONTARECEBERID1,
                        principalTable: "CONTA_RECEBER",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BAIXA_FINANCEIRA_FORMA_PAGAMENTO_FORMAPAGAMENTOID",
                        column: x => x.FORMAPAGAMENTOID,
                        principalTable: "FORMA_PAGAMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BAIXA_FINANCEIRA_CONTABANCARIAEMPRESAID",
                table: "BAIXA_FINANCEIRA",
                column: "CONTABANCARIAEMPRESAID");

            migrationBuilder.CreateIndex(
                name: "IX_BAIXA_FINANCEIRA_CONTAPAGARID",
                table: "BAIXA_FINANCEIRA",
                column: "CONTAPAGARID");

            migrationBuilder.CreateIndex(
                name: "IX_BAIXA_FINANCEIRA_CONTARECEBERID",
                table: "BAIXA_FINANCEIRA",
                column: "CONTARECEBERID");

            migrationBuilder.CreateIndex(
                name: "IX_BAIXA_FINANCEIRA_CONTARECEBERID1",
                table: "BAIXA_FINANCEIRA",
                column: "CONTARECEBERID1");

            migrationBuilder.CreateIndex(
                name: "IX_BAIXA_FINANCEIRA_FORMAPAGAMENTOID",
                table: "BAIXA_FINANCEIRA",
                column: "FORMAPAGAMENTOID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_PAGAR_CATEGORIAFINANCEIRAID",
                table: "CONTA_PAGAR",
                column: "CATEGORIAFINANCEIRAID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_PAGAR_CENTROCUSTOID",
                table: "CONTA_PAGAR",
                column: "CENTROCUSTOID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_PAGAR_CONTRATOID",
                table: "CONTA_PAGAR",
                column: "CONTRATOID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_PAGAR_PESSOAID",
                table: "CONTA_PAGAR",
                column: "PESSOAID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_RECEBER_CATEGORIAFINANCEIRAID",
                table: "CONTA_RECEBER",
                column: "CATEGORIAFINANCEIRAID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_RECEBER_CENTROCUSTOID",
                table: "CONTA_RECEBER",
                column: "CENTROCUSTOID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_RECEBER_CONTRATOID",
                table: "CONTA_RECEBER",
                column: "CONTRATOID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_RECEBER_PESSOAID",
                table: "CONTA_RECEBER",
                column: "PESSOAID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRATO_PESSOAID",
                table: "CONTRATO",
                column: "PESSOAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BAIXA_FINANCEIRA");

            migrationBuilder.DropTable(
                name: "CONTABANCARIAEMPRESA");

            migrationBuilder.DropTable(
                name: "CONTA_PAGAR");

            migrationBuilder.DropTable(
                name: "CONTA_RECEBER");

            migrationBuilder.DropTable(
                name: "FORMA_PAGAMENTO");

            migrationBuilder.DropTable(
                name: "CATEGORIA_FINANCEIRA");

            migrationBuilder.DropTable(
                name: "CENTRO_CUSTO");

            migrationBuilder.DropTable(
                name: "CONTRATO");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "VARA");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "VARA");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "VARA");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "VARA");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "VARA");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "VARA");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "SETORES");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "SETORES");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "SETORES");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "SETORES");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "SETORES");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "SETORES");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "QUALIFICACAO");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "QUALIFICACAO");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "QUALIFICACAO");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "QUALIFICACAO");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "QUALIFICACAO");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "QUALIFICACAO");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "NIVEL");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "NIVEL");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "NIVEL");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "NIVEL");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "NIVEL");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "NIVEL");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "LOGINHISTORY");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "LOGINHISTORY");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "LOGINHISTORY");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "LOGINHISTORY");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "LOGINHISTORY");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "LOGINHISTORY");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "HISTORICOGERAL");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "HISTORICOGERAL");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "HISTORICOGERAL");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "HISTORICOGERAL");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "HISTORICOGERAL");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "HISTORICOGERAL");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "FOTOS");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "FOTOS");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "FOTOS");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "FOTOS");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "FORO");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "FORO");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "FORO");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "FORO");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "FORO");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "FORO");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "ETIQUETA");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "ETIQUETA");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "ETIQUETA");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "ETIQUETA");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "ETIQUETA");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "ETIQUETA");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "ENDERECO");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "ENDERECO");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "ENDERECO");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "ENDERECO");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "ENDERECO");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "ENDERECO");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "CONTABANCARIA");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "CONTABANCARIA");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "CONTABANCARIA");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "CONTABANCARIA");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "CONTABANCARIA");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "CONTABANCARIA");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "COMENTARIOS");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "COMENTARIOS");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "COMENTARIOS");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "COMENTARIOS");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "COMENTARIOS");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "COMENTARIOS");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "CASO");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "CASO");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "CASO");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "ATENDIMENTOHISTORICO");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "ATENDIMENTOHISTORICO");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "ATENDIMENTOHISTORICO");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "ATENDIMENTOHISTORICO");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "ATENDIMENTOHISTORICO");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "ATENDIMENTOHISTORICO");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "DATAATUALIZACAO",
                table: "ACAO");

            migrationBuilder.DropColumn(
                name: "DATACADASTRO",
                table: "ACAO");

            migrationBuilder.DropColumn(
                name: "DATAEXCLUSAO",
                table: "ACAO");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "ACAO");

            migrationBuilder.DropColumn(
                name: "USUARIOCADASTROID",
                table: "ACAO");

            migrationBuilder.DropColumn(
                name: "USUARIOEXCLUSAOID",
                table: "ACAO");
        }
    }
}
