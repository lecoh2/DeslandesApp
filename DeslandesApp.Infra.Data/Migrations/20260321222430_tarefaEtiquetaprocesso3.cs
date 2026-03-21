using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class tarefaEtiquetaprocesso3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ATENDIMENTOPAIID",
                table: "TAREFA",
                newName: "ATENDIMENTOID");

            migrationBuilder.CreateIndex(
                name: "IX_TAREFA_ATENDIMENTOID",
                table: "TAREFA",
                column: "ATENDIMENTOID");

            migrationBuilder.CreateIndex(
                name: "IX_TAREFA_CASOID",
                table: "TAREFA",
                column: "CASOID");

            migrationBuilder.CreateIndex(
                name: "IX_TAREFA_PROCESSOID",
                table: "TAREFA",
                column: "PROCESSOID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_ATENDIMENTO",
                table: "TAREFA",
                column: "ATENDIMENTOID",
                principalTable: "ATENDIMENTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_CASO",
                table: "TAREFA",
                column: "CASOID",
                principalTable: "CASO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_PROCESSO",
                table: "TAREFA",
                column: "PROCESSOID",
                principalTable: "PROCESSOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_ATENDIMENTO",
                table: "TAREFA");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_CASO",
                table: "TAREFA");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_PROCESSO",
                table: "TAREFA");

            migrationBuilder.DropIndex(
                name: "IX_TAREFA_ATENDIMENTOID",
                table: "TAREFA");

            migrationBuilder.DropIndex(
                name: "IX_TAREFA_CASOID",
                table: "TAREFA");

            migrationBuilder.DropIndex(
                name: "IX_TAREFA_PROCESSOID",
                table: "TAREFA");

            migrationBuilder.RenameColumn(
                name: "ATENDIMENTOID",
                table: "TAREFA",
                newName: "ATENDIMENTOPAIID");
        }
    }
}
