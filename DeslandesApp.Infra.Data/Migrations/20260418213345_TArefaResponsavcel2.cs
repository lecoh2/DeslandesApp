using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TArefaResponsavcel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFARESPONSAVEIS_PESSOA",
                table: "GRUPOTAREFARESPONSAVEIS");

            migrationBuilder.RenameColumn(
                name: "PESSOAID",
                table: "GRUPOTAREFARESPONSAVEIS",
                newName: "USUARIOID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFARESPONSAVEIS_TAREFAID_PESSOAID",
                table: "GRUPOTAREFARESPONSAVEIS",
                newName: "IX_GRUPOTAREFARESPONSAVEIS_TAREFAID_USUARIOID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFARESPONSAVEIS_USUARIO",
                table: "GRUPOTAREFARESPONSAVEIS",
                column: "USUARIOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFARESPONSAVEIS_USUARIO",
                table: "GRUPOTAREFARESPONSAVEIS");

            migrationBuilder.RenameColumn(
                name: "USUARIOID",
                table: "GRUPOTAREFARESPONSAVEIS",
                newName: "PESSOAID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFARESPONSAVEIS_TAREFAID_USUARIOID",
                table: "GRUPOTAREFARESPONSAVEIS",
                newName: "IX_GRUPOTAREFARESPONSAVEIS_TAREFAID_PESSOAID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFARESPONSAVEIS_PESSOA",
                table: "GRUPOTAREFARESPONSAVEIS",
                column: "PESSOAID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
