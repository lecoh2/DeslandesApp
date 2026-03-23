using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class eventocorigido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENTORESPONSAVEL_PESSOA_PESSOAID",
                table: "EVENTORESPONSAVEL");

            migrationBuilder.RenameColumn(
                name: "PESSOAID",
                table: "EVENTORESPONSAVEL",
                newName: "USUARIOID");

            migrationBuilder.RenameIndex(
                name: "IX_EVENTORESPONSAVEL_PESSOAID",
                table: "EVENTORESPONSAVEL",
                newName: "IX_EVENTORESPONSAVEL_USUARIOID");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTORESPONSAVEL_USUARIOS_USUARIOID",
                table: "EVENTORESPONSAVEL",
                column: "USUARIOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENTORESPONSAVEL_USUARIOS_USUARIOID",
                table: "EVENTORESPONSAVEL");

            migrationBuilder.RenameColumn(
                name: "USUARIOID",
                table: "EVENTORESPONSAVEL",
                newName: "PESSOAID");

            migrationBuilder.RenameIndex(
                name: "IX_EVENTORESPONSAVEL_USUARIOID",
                table: "EVENTORESPONSAVEL",
                newName: "IX_EVENTORESPONSAVEL_PESSOAID");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTORESPONSAVEL_PESSOA_PESSOAID",
                table: "EVENTORESPONSAVEL",
                column: "PESSOAID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
