using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAREFA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DATATAREFA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAREFA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LISTATAREFA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TAREFAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROCESSOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RESPONSAVELID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PRIORIDADE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LISTATAREFA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LISTATAREFA_PESSOA",
                        column: x => x.RESPONSAVELID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LISTATAREFA_PROCESSO",
                        column: x => x.PROCESSOID,
                        principalTable: "PROCESSOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAREFA_LISTATAREFA",
                        column: x => x.TAREFAID,
                        principalTable: "TAREFA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GRUPOTAREFAENVOLVIDO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LISTATAREFAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PESSOAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOTAREFAENVOLVIDO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TAREFAENVOLVIDO_LISTATAREFA",
                        column: x => x.LISTATAREFAID,
                        principalTable: "LISTATAREFA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAREFAENVOLVIDO_PESSOA",
                        column: x => x.PESSOAID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_LISTATAREFAID",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "LISTATAREFAID");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_PESSOAID",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "PESSOAID");

            migrationBuilder.CreateIndex(
                name: "IX_LISTATAREFA_PROCESSOID",
                table: "LISTATAREFA",
                column: "PROCESSOID");

            migrationBuilder.CreateIndex(
                name: "IX_LISTATAREFA_RESPONSAVELID",
                table: "LISTATAREFA",
                column: "RESPONSAVELID");

            migrationBuilder.CreateIndex(
                name: "IX_LISTATAREFA_TAREFAID",
                table: "LISTATAREFA",
                column: "TAREFAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropTable(
                name: "LISTATAREFA");

            migrationBuilder.DropTable(
                name: "TAREFA");
        }
    }
}
