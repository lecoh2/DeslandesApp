using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Etiqueta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATENDIMENTO_ETIQUETA_ETIQUETA_ETIQUETAID",
                table: "ATENDIMENTO_ETIQUETA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ATENDIMENTO_ETIQUETA",
                table: "ATENDIMENTO_ETIQUETA");

            migrationBuilder.RenameTable(
                name: "ATENDIMENTO_ETIQUETA",
                newName: "GRUPOATENDIMENTOETIQUETA");

            migrationBuilder.RenameIndex(
                name: "IX_ATENDIMENTO_ETIQUETA_ETIQUETAID",
                table: "GRUPOATENDIMENTOETIQUETA",
                newName: "IX_GRUPOATENDIMENTOETIQUETA_ETIQUETAID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GRUPOATENDIMENTOETIQUETA",
                table: "GRUPOATENDIMENTOETIQUETA",
                columns: new[] { "ATENDIMENTOID", "ETIQUETAID" });

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOATENDIMENTOETIQUETA_ETIQUETA_ETIQUETAID",
                table: "GRUPOATENDIMENTOETIQUETA",
                column: "ETIQUETAID",
                principalTable: "ETIQUETA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOATENDIMENTOETIQUETA_ETIQUETA_ETIQUETAID",
                table: "GRUPOATENDIMENTOETIQUETA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GRUPOATENDIMENTOETIQUETA",
                table: "GRUPOATENDIMENTOETIQUETA");

            migrationBuilder.RenameTable(
                name: "GRUPOATENDIMENTOETIQUETA",
                newName: "ATENDIMENTO_ETIQUETA");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOATENDIMENTOETIQUETA_ETIQUETAID",
                table: "ATENDIMENTO_ETIQUETA",
                newName: "IX_ATENDIMENTO_ETIQUETA_ETIQUETAID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ATENDIMENTO_ETIQUETA",
                table: "ATENDIMENTO_ETIQUETA",
                columns: new[] { "ATENDIMENTOID", "ETIQUETAID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ATENDIMENTO_ETIQUETA_ETIQUETA_ETIQUETAID",
                table: "ATENDIMENTO_ETIQUETA",
                column: "ETIQUETAID",
                principalTable: "ETIQUETA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
