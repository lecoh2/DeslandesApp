using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CasoEventos22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFAENVOLVIDO_PESSOA",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.RenameColumn(
                name: "PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "USUARIOID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "IX_GRUPOTAREFAENVOLVIDO_USUARIOID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFAENVOLVIDO_USUARIOS",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "USUARIOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFAENVOLVIDO_USUARIOS",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.RenameColumn(
                name: "USUARIOID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "PESSOAID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_USUARIOID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFAENVOLVIDO_PESSOA",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "PESSOAID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
