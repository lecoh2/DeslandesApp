using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoTarefaResponsaveis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFAENVOLVIDO_PESSOA",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_ENVOLVIDO",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFARESPONSAVEIS_PESSOA",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "PESSOAID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFARESPONSAVEIS_TAREFA",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "TAREFAID",
                principalTable: "TAREFA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFARESPONSAVEIS_PESSOA",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFARESPONSAVEIS_TAREFA",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFAENVOLVIDO_PESSOA",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "PESSOAID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_ENVOLVIDO",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "TAREFAID",
                principalTable: "TAREFA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
