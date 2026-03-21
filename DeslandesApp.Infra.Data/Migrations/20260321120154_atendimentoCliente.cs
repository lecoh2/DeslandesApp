using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class atendimentoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATENDIMENTCLIENTE_PESSOA_PESSOAID",
                table: "ATENDIMENTCLIENTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ATENDIMENTCLIENTE",
                table: "ATENDIMENTCLIENTE");

            migrationBuilder.RenameTable(
                name: "ATENDIMENTCLIENTE",
                newName: "GRUPOATENDIMENTOCLIENTE");

            migrationBuilder.RenameIndex(
                name: "IX_ATENDIMENTCLIENTE_PESSOAID",
                table: "GRUPOATENDIMENTOCLIENTE",
                newName: "IX_GRUPOATENDIMENTOCLIENTE_PESSOAID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GRUPOATENDIMENTOCLIENTE",
                table: "GRUPOATENDIMENTOCLIENTE",
                columns: new[] { "ATENDIMENTOID", "PESSOAID" });

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPOATENDIMENTOCLIENTE_PESSOA_PESSOAID",
                table: "GRUPOATENDIMENTOCLIENTE",
                column: "PESSOAID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPOATENDIMENTOCLIENTE_PESSOA_PESSOAID",
                table: "GRUPOATENDIMENTOCLIENTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GRUPOATENDIMENTOCLIENTE",
                table: "GRUPOATENDIMENTOCLIENTE");

            migrationBuilder.RenameTable(
                name: "GRUPOATENDIMENTOCLIENTE",
                newName: "ATENDIMENTCLIENTE");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOATENDIMENTOCLIENTE_PESSOAID",
                table: "ATENDIMENTCLIENTE",
                newName: "IX_ATENDIMENTCLIENTE_PESSOAID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ATENDIMENTCLIENTE",
                table: "ATENDIMENTCLIENTE",
                columns: new[] { "ATENDIMENTOID", "PESSOAID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ATENDIMENTCLIENTE_PESSOA_PESSOAID",
                table: "ATENDIMENTCLIENTE",
                column: "PESSOAID",
                principalTable: "PESSOA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
