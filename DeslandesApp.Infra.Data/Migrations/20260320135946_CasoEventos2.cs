using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CasoEventos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LISTATAREFA_PESSOA",
                table: "LISTATAREFA");

            migrationBuilder.AddForeignKey(
                name: "FK_LISTATAREFA_PESSOA",
                table: "LISTATAREFA",
                column: "RESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LISTATAREFA_PESSOA",
                table: "LISTATAREFA");

            migrationBuilder.AddForeignKey(
                name: "FK_LISTATAREFA_PESSOA",
                table: "LISTATAREFA",
                column: "RESPONSAVELID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
