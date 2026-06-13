using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCamposQuitacaoContaPagarreceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BAIXA_FINANCEIRA_FORMA_PAGAMENTO_FORMAPAGAMENTOID",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.DropTable(
                name: "FORMA_PAGAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_BAIXA_FINANCEIRA_FORMAPAGAMENTOID",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.DropColumn(
                name: "FORMAPAGAMENTOID",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.AddColumn<int>(
                name: "FORMARECEBIMENTO",
                table: "BAIXA_FINANCEIRA",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FORMARECEBIMENTO",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.AddColumn<Guid>(
                name: "FORMAPAGAMENTOID",
                table: "BAIXA_FINANCEIRA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "FORMA_PAGAMENTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIOCADASTROID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAEXCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXCLUIDO = table.Column<bool>(type: "bit", nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    USUARIOATUALIZACAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USUARIOEXCLUSAOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMA_PAGAMENTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FORMA_PAGAMENTO_USUARIOS_USUARIOCADASTROID",
                        column: x => x.USUARIOCADASTROID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BAIXA_FINANCEIRA_FORMAPAGAMENTOID",
                table: "BAIXA_FINANCEIRA",
                column: "FORMAPAGAMENTOID");

            migrationBuilder.CreateIndex(
                name: "IX_FORMA_PAGAMENTO_USUARIOCADASTROID",
                table: "FORMA_PAGAMENTO",
                column: "USUARIOCADASTROID");

            migrationBuilder.AddForeignKey(
                name: "FK_BAIXA_FINANCEIRA_FORMA_PAGAMENTO_FORMAPAGAMENTOID",
                table: "BAIXA_FINANCEIRA",
                column: "FORMAPAGAMENTOID",
                principalTable: "FORMA_PAGAMENTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
