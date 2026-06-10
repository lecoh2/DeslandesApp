using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class baixa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "VARA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "USUARIOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "SETORES",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "QUALIFICACAO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "NIVEL",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "LOGINHISTORY",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "LISTATAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "HISTORICOGERAL",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "GRUPOCASOENVOLVIDO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "FOTOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "FORO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "FORMA_PAGAMENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "FAILEDLOGINATTEMPTS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "EVENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "ETIQUETA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "ENDERECO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "CONTRATO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "CONTABANCARIAEMPRESA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "CONTABANCARIA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TOTALPARCELAS",
                table: "CONTA_RECEBER",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NUMEROPARCELA",
                table: "CONTA_RECEBER",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAQUITACAO",
                table: "CONTA_RECEBER",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "QUITADO",
                table: "CONTA_RECEBER",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "CONTA_RECEBER",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VALORRECEBIDO",
                table: "CONTA_RECEBER",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "CONTA_PAGAR",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "COMENTARIOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "CENTRO_CUSTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "CATEGORIA_FINANCEIRA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "CASO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "BAIXA_FINANCEIRA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "ATENDIMENTOHISTORICO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "ATENDIMENTO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIOATUALIZACAOID",
                table: "ACAO",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "VARA");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "SETORES");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "QUALIFICACAO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "NIVEL");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "LOGINHISTORY");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "HISTORICOGERAL");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "GRUPOCASOENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "FOTOS");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "FORO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "FORMA_PAGAMENTO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "FAILEDLOGINATTEMPTS");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "EVENTO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "ETIQUETA");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "ENDERECO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "CONTRATO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "CONTABANCARIAEMPRESA");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "CONTABANCARIA");

            migrationBuilder.DropColumn(
                name: "DATAQUITACAO",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "QUITADO",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "VALORRECEBIDO",
                table: "CONTA_RECEBER");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "CONTA_PAGAR");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "COMENTARIOS");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "CENTRO_CUSTO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "CATEGORIA_FINANCEIRA");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "CASO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "ATENDIMENTOHISTORICO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "ATENDIMENTO");

            migrationBuilder.DropColumn(
                name: "USUARIOATUALIZACAOID",
                table: "ACAO");

            migrationBuilder.AlterColumn<int>(
                name: "TOTALPARCELAS",
                table: "CONTA_RECEBER",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NUMEROPARCELA",
                table: "CONTA_RECEBER",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
