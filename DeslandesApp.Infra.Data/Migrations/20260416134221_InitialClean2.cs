using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialClean2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOETIQUETASPROCESSOS_PESSOA_PESSOAID",
                table: "GRUPOETIQUETASPROCESSOS");

            migrationBuilder.RenameColumn(
                name: "PESSOAID",
                table: "GRUPOETIQUETASPROCESSOS",
                newName: "PESSOAID1");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOETIQUETASPROCESSOS_PESSOAID",
                table: "GRUPOETIQUETASPROCESSOS",
                newName: "IX_GRUPOETIQUETASPROCESSOS_PESSOAID1");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOETIQUETASPROCESSOS_PESSOA_PESSOAID1",
                table: "GRUPOETIQUETASPROCESSOS",
                column: "PESSOAID1",
                principalTable: "PESSOA",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOETIQUETASPROCESSOS_PESSOA_PESSOAID1",
                table: "GRUPOETIQUETASPROCESSOS");

            migrationBuilder.RenameColumn(
                name: "PESSOAID1",
                table: "GRUPOETIQUETASPROCESSOS",
                newName: "PESSOAID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOETIQUETASPROCESSOS_PESSOAID1",
                table: "GRUPOETIQUETASPROCESSOS",
                newName: "IX_GRUPOETIQUETASPROCESSOS_PESSOAID");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOETIQUETASPROCESSOS_PESSOA_PESSOAID",
                table: "GRUPOETIQUETASPROCESSOS",
                column: "PESSOAID",
                principalTable: "PESSOA",
                principalColumn: "ID");
        }
    }
}
