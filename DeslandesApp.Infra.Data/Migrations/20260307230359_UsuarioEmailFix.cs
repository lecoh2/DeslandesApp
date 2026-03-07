using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioEmailFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_ValorEmail",
                table: "USUARIOS");

            migrationBuilder.RenameColumn(
                name: "ValorEmail",
                table: "USUARIOS",
                newName: "EMAIL");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_EMAIL",
                table: "USUARIOS",
                column: "EMAIL",
                unique: true,
                filter: "[EMAIL] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_EMAIL",
                table: "USUARIOS");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "USUARIOS",
                newName: "ValorEmail");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ValorEmail",
                table: "USUARIOS",
                column: "ValorEmail",
                unique: true,
                filter: "[ValorEmail] IS NOT NULL");
        }
    }
}
