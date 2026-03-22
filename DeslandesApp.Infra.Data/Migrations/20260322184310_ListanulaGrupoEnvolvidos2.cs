using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ListanulaGrupoEnvolvidos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "USUARIOID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "PESOAID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_USUARIOID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "IX_GRUPOTAREFAENVOLVIDO_PESOAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PESOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "USUARIOID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "IX_GRUPOTAREFAENVOLVIDO_USUARIOID");
        }
    }
}
