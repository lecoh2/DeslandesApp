using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TipoConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONTABANCARIA",
                columns: table => new
                {
                    NUMEROCONTA = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    NOMEBANCO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AGENCIA = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PIX = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TIPOCONTAID = table.Column<int>(type: "int", nullable: true),
                    TIPOCONTA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTABANCARIA", x => x.NUMEROCONTA);
                    table.ForeignKey(
                        name: "FK_CONTABANCARIA_PESSOA_PESSOAID",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTABANCARIA_PESSOAID",
                table: "CONTABANCARIA",
                column: "PESSOAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTABANCARIA");
        }
    }
}
