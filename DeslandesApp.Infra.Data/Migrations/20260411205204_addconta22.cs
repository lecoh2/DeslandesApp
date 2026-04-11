using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class addconta22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_SEXO_SEXOID",
                table: "PESSOA");

            migrationBuilder.DropTable(
                name: "SEXO");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_SEXOID",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "SEXOID",
                table: "PESSOA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SEXOID",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_SEXOID",
                table: "PESSOA",
                column: "SEXOID");

            migrationBuilder.CreateIndex(
                name: "IX_SEXO_NOMESEXO",
                table: "SEXO",
                column: "NOMESEXO",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_SEXO_SEXOID",
                table: "PESSOA",
                column: "SEXOID",
                principalTable: "SEXO",
                principalColumn: "ID");
        }
    }
}
