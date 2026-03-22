using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ListanulaGrupoEnvolvidos23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOTAREFAENVOLVIDO_PESSOA_PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_TAREFAID",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.RenameColumn(
                name: "PESOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "PESSOAID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_TAREFAID_PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                columns: new[] { "TAREFAID", "PESSOAID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_TAREFAID_PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.RenameColumn(
                name: "PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "PESOAID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "IX_GRUPOTAREFAENVOLVIDO_PESOAID");

            migrationBuilder.AddColumn<Guid>(
                name: "PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "PESSOAID1");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_TAREFAID",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "TAREFAID");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOTAREFAENVOLVIDO_PESSOA_PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "PESSOAID1",
                principalTable: "PESSOA",
                principalColumn: "ID");
        }
    }
}
