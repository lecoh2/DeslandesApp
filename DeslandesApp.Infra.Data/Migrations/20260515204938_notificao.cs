using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class notificao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NOTIFICACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TITULO = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    MENSAGEM = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    LIDA = table.Column<bool>(type: "bit", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUARIOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TIPO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    REFERENCIAID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTIFICACAO_USUARIOS_USUARIOID",
                        column: x => x.USUARIOID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACAO_USUARIOID",
                table: "NOTIFICACAO",
                column: "USUARIOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTIFICACAO");
        }
    }
}
