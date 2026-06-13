using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCamposQuitacaoContaPagar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BAIXA_FINANCEIRA_CONTA_PAGAR_CONTAPAGARID",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.DropForeignKey(
                name: "FK_CONTA_PAGAR_CONTA_PAGAR_CONTAPAIID",
                table: "CONTA_PAGAR");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAQUITACAO",
                table: "CONTA_PAGAR",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "QUITADO",
                table: "CONTA_PAGAR",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BAIXACONTAPAGAR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CONTAPAGARID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATAPAGAMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VALORPAGO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FORMAPAGAMENTO = table.Column<int>(type: "int", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
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
                    table.PrimaryKey("PK_BAIXACONTAPAGAR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BAIXACONTAPAGAR_CONTA_PAGAR_CONTAPAGARID",
                        column: x => x.CONTAPAGARID,
                        principalTable: "CONTA_PAGAR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BAIXACONTAPAGAR_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BAIXACONTAPAGAR_CONTAPAGARID",
                table: "BAIXACONTAPAGAR",
                column: "CONTAPAGARID");

            migrationBuilder.CreateIndex(
                name: "IX_BAIXACONTAPAGAR_USUARIOCADASTROID",
                table: "BAIXACONTAPAGAR",
                column: "USUARIOCADASTROID");

            migrationBuilder.AddForeignKey(
                name: "FK_BAIXA_FINANCEIRA_CONTA_PAGAR_CONTAPAGARID",
                table: "BAIXA_FINANCEIRA",
                column: "CONTAPAGARID",
                principalTable: "CONTA_PAGAR",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CONTA_PAGAR_CONTA_PAGAR_CONTAPAIID",
                table: "CONTA_PAGAR",
                column: "CONTAPAIID",
                principalTable: "CONTA_PAGAR",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BAIXA_FINANCEIRA_CONTA_PAGAR_CONTAPAGARID",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.DropForeignKey(
                name: "FK_CONTA_PAGAR_CONTA_PAGAR_CONTAPAIID",
                table: "CONTA_PAGAR");

            migrationBuilder.DropTable(
                name: "BAIXACONTAPAGAR");

            migrationBuilder.DropColumn(
                name: "DATAQUITACAO",
                table: "CONTA_PAGAR");

            migrationBuilder.DropColumn(
                name: "QUITADO",
                table: "CONTA_PAGAR");

            migrationBuilder.AddForeignKey(
                name: "FK_BAIXA_FINANCEIRA_CONTA_PAGAR_CONTAPAGARID",
                table: "BAIXA_FINANCEIRA",
                column: "CONTAPAGARID",
                principalTable: "CONTA_PAGAR",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CONTA_PAGAR_CONTA_PAGAR_CONTAPAIID",
                table: "CONTA_PAGAR",
                column: "CONTAPAIID",
                principalTable: "CONTA_PAGAR",
                principalColumn: "ID");
        }
    }
}
