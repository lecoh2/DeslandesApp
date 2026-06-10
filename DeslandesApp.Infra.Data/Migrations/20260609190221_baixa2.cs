using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class baixa2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BAIXA_FINANCEIRA_CONTA_RECEBER_CONTARECEBERID1",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.DropIndex(
                name: "IX_BAIXA_FINANCEIRA_CONTARECEBERID1",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.DropColumn(
                name: "CONTARECEBERID1",
                table: "BAIXA_FINANCEIRA");

            migrationBuilder.CreateTable(
                name: "CONTARECEBERBAIXA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CONTARECEBERID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALORPAGO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATABAIXA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FORMARECEBIMENTO = table.Column<int>(type: "int", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTARECEBERBAIXA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTARECEBERBAIXA_CONTA_RECEBER_CONTARECEBERID",
                        column: x => x.CONTARECEBERID,
                        principalTable: "CONTA_RECEBER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTARECEBERBAIXA_CONTARECEBERID",
                table: "CONTARECEBERBAIXA",
                column: "CONTARECEBERID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTARECEBERBAIXA");

            migrationBuilder.AddColumn<Guid>(
                name: "CONTARECEBERID1",
                table: "BAIXA_FINANCEIRA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BAIXA_FINANCEIRA_CONTARECEBERID1",
                table: "BAIXA_FINANCEIRA",
                column: "CONTARECEBERID1");

            migrationBuilder.AddForeignKey(
                name: "FK_BAIXA_FINANCEIRA_CONTA_RECEBER_CONTARECEBERID1",
                table: "BAIXA_FINANCEIRA",
                column: "CONTARECEBERID1",
                principalTable: "CONTA_RECEBER",
                principalColumn: "ID");
        }
    }
}
