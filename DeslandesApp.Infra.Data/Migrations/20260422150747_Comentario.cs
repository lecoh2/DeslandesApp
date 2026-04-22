using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Comentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMENTARIOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TEXTO = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUARIOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TAREFAID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EVENTOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMENTARIOS", x => x.ID);
                    table.CheckConstraint("CK_Comentario_Vinculo", "[TarefaId] IS NOT NULL OR [EventoId] IS NOT NULL");
                    table.ForeignKey(
                        name: "FK_COMENTARIOS_EVENTO_EVENTOID",
                        column: x => x.EVENTOID,
                        principalTable: "EVENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMENTARIOS_TAREFA_TAREFAID",
                        column: x => x.TAREFAID,
                        principalTable: "TAREFA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMENTARIOS_USUARIOS_USUARIOID",
                        column: x => x.USUARIOID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMENTARIOS_EVENTOID",
                table: "COMENTARIOS",
                column: "EVENTOID");

            migrationBuilder.CreateIndex(
                name: "IX_COMENTARIOS_TAREFAID",
                table: "COMENTARIOS",
                column: "TAREFAID");

            migrationBuilder.CreateIndex(
                name: "IX_COMENTARIOS_USUARIOID",
                table: "COMENTARIOS",
                column: "USUARIOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMENTARIOS");
        }
    }
}
