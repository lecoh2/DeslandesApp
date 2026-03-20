using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CasoEventosAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LISTATAREFA_PESSOA",
                table: "LISTATAREFA");

            migrationBuilder.DropForeignKey(
                name: "FK_LISTATAREFA_PROCESSO",
                table: "LISTATAREFA");

            migrationBuilder.DropIndex(
                name: "IX_LISTATAREFA_PROCESSOID",
                table: "LISTATAREFA");

            migrationBuilder.RenameColumn(
                name: "PROCESSOID",
                table: "LISTATAREFA",
                newName: "VINCULOID");

            migrationBuilder.AddColumn<int>(
                name: "TIPOVINCULO",
                table: "LISTATAREFA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LISTATAREFA_USUARIO",
                table: "LISTATAREFA",
                column: "RESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LISTATAREFA_USUARIO",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "TIPOVINCULO",
                table: "LISTATAREFA");

            migrationBuilder.RenameColumn(
                name: "VINCULOID",
                table: "LISTATAREFA",
                newName: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_LISTATAREFA_PROCESSOID",
                table: "LISTATAREFA",
                column: "PROCESSOID");

            migrationBuilder.AddForeignKey(
                name: "FK_LISTATAREFA_PESSOA",
                table: "LISTATAREFA",
                column: "RESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LISTATAREFA_PROCESSO",
                table: "LISTATAREFA",
                column: "PROCESSOID",
                principalTable: "PROCESSOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
