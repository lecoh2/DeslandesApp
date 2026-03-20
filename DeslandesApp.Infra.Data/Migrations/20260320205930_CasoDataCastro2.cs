using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CasoDataCastro2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CASO_PESSOA",
                table: "CASO");

            migrationBuilder.AddForeignKey(
                name: "FK_CASO_USUARIO",
                table: "CASO",
                column: "RESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CASO_USUARIO",
                table: "CASO");

            migrationBuilder.AddForeignKey(
                name: "FK_CASO_PESSOA",
                table: "CASO",
                column: "RESPONSAVELID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
