using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ListanulaGrupoEnvolvidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFAENVOLVIDO_USUARIO",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.AddColumn<Guid>(
                name: "PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "PESSOAID1");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOTAREFAENVOLVIDO_PESSOA_PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "PESSOAID1",
                principalTable: "PESSOA",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFAENVOLVIDO_PESSOA",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "USUARIOID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOTAREFAENVOLVIDO_PESSOA_PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFAENVOLVIDO_PESSOA",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropColumn(
                name: "PESSOAID1",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFAENVOLVIDO_USUARIO",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "USUARIOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
