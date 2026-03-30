using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoTarefaResponsaveis2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GRUPOTAREFAENVOLVIDO",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.RenameTable(
                name: "GRUPOTAREFAENVOLVIDO",
                newName: "GRUPOTAREFARESPONSAVEIS");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_TAREFAID_PESSOAID",
                table: "GRUPOTAREFARESPONSAVEIS",
                newName: "IX_GRUPOTAREFARESPONSAVEIS_TAREFAID_PESSOAID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GRUPOTAREFARESPONSAVEIS",
                table: "GRUPOTAREFARESPONSAVEIS",
                columns: new[] { "PESSOAID", "TAREFAID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GRUPOTAREFARESPONSAVEIS",
                table: "GRUPOTAREFARESPONSAVEIS");

            migrationBuilder.RenameTable(
                name: "GRUPOTAREFARESPONSAVEIS",
                newName: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFARESPONSAVEIS_TAREFAID_PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "IX_GRUPOTAREFAENVOLVIDO_TAREFAID_PESSOAID");

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "GRUPOTAREFAENVOLVIDO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GRUPOTAREFAENVOLVIDO",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "PESSOAID");
        }
    }
}
