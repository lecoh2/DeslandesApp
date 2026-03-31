using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtendiemntoUpdateHistgorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATENDIMENTOHISTORICO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ATENDIMENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "VARCHAR(255)", unicode: false, maxLength: 250, nullable: true),
                    DADOSANTES = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true),
                    DADOSDEPOIS = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATENDIMENTOHISTORICO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ATENDIMENTOHISTORICO_ATENDIMENTO",
                        column: x => x.ATENDIMENTO_ID,
                        principalTable: "ATENDIMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ATENDIMENTOHISTORICO_USUARIO",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTOHISTORICO_ATENDIMENTO_ID",
                table: "ATENDIMENTOHISTORICO",
                column: "ATENDIMENTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTOHISTORICO_USUARIO_ID",
                table: "ATENDIMENTOHISTORICO",
                column: "USUARIO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATENDIMENTOHISTORICO");
        }
    }
}
