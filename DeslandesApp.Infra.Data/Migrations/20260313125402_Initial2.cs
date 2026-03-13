using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INFORMACOESCOMPLEMENTARES_PESSOA_IdPessoa",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "INFORMACOESCOMPLEMENTARES",
                newName: "PESSOA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_INFORMACOESCOMPLEMENTARES_IdPessoa",
                table: "INFORMACOESCOMPLEMENTARES",
                newName: "IX_INFORMACOESCOMPLEMENTARES_PESSOA_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_INFORMACOESCOMPLEMENTARES_PESSOA_PESSOA_ID",
                table: "INFORMACOESCOMPLEMENTARES",
                column: "PESSOA_ID",
                principalTable: "PESSOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INFORMACOESCOMPLEMENTARES_PESSOA_PESSOA_ID",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.RenameColumn(
                name: "PESSOA_ID",
                table: "INFORMACOESCOMPLEMENTARES",
                newName: "IdPessoa");

            migrationBuilder.RenameIndex(
                name: "IX_INFORMACOESCOMPLEMENTARES_PESSOA_ID",
                table: "INFORMACOESCOMPLEMENTARES",
                newName: "IX_INFORMACOESCOMPLEMENTARES_IdPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_INFORMACOESCOMPLEMENTARES_PESSOA_IdPessoa",
                table: "INFORMACOESCOMPLEMENTARES",
                column: "IdPessoa",
                principalTable: "PESSOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
