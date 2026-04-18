using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class grupoTarefaEtiquetas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TAREFAETIQUETA",
                table: "TAREFAETIQUETA");

            migrationBuilder.RenameTable(
                name: "TAREFAETIQUETA",
                newName: "GRUPOTAREFASETIQUETAS");

            migrationBuilder.RenameIndex(
                name: "IX_TAREFAETIQUETA_ETIQUETAID",
                table: "GRUPOTAREFASETIQUETAS",
                newName: "IX_GRUPOTAREFASETIQUETAS_ETIQUETAID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GRUPOTAREFASETIQUETAS",
                table: "GRUPOTAREFASETIQUETAS",
                columns: new[] { "TAREFAID", "ETIQUETAID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GRUPOTAREFASETIQUETAS",
                table: "GRUPOTAREFASETIQUETAS");

            migrationBuilder.RenameTable(
                name: "GRUPOTAREFASETIQUETAS",
                newName: "TAREFAETIQUETA");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFASETIQUETAS_ETIQUETAID",
                table: "TAREFAETIQUETA",
                newName: "IX_TAREFAETIQUETA_ETIQUETAID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TAREFAETIQUETA",
                table: "TAREFAETIQUETA",
                columns: new[] { "TAREFAID", "ETIQUETAID" });
        }
    }
}
