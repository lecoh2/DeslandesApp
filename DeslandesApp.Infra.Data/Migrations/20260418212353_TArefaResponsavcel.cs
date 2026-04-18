using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TArefaResponsavcel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_USUARIO",
                table: "TAREFA");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_USUARIOS_RESPONSAVELID",
                table: "TAREFA",
                column: "RESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_USUARIOS_RESPONSAVELID",
                table: "TAREFA");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_USUARIO",
                table: "TAREFA",
                column: "RESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
