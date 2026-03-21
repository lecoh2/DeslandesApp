using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class tarefaEtiquetaprocesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFAENVOLVIDO_LISTATAREFA",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFAENVOLVIDO_USUARIOS",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_LISTATAREFA_USUARIO",
                table: "LISTATAREFA");

            migrationBuilder.DropIndex(
                name: "IX_LISTATAREFA_RESPONSAVELID",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "PRIORIDADE",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "RESPONSAVELID",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "VINCULOID",
                table: "LISTATAREFA");

            migrationBuilder.RenameColumn(
                name: "TIPOVINCULO",
                table: "LISTATAREFA",
                newName: "ORDEM");

            migrationBuilder.RenameColumn(
                name: "LISTATAREFAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "TAREFAID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_LISTATAREFAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "IX_GRUPOTAREFAENVOLVIDO_TAREFAID");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "TAREFA",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA",
                table: "TAREFA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PRIORIDADE",
                table: "TAREFA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RESPONSAVELID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TIPOVINCULO",
                table: "TAREFA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "VINCULOID",
                table: "TAREFA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "CONCLUIDA",
                table: "LISTATAREFA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATACONCLUSAO",
                table: "LISTATAREFA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DESCRICAO",
                table: "LISTATAREFA",
                type: "varchar(300)",
                unicode: false,
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TAREFAETIQUETA",
                columns: table => new
                {
                    TAREFAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ETIQUETAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAREFAETIQUETA", x => new { x.TAREFAID, x.ETIQUETAID });
                    table.ForeignKey(
                        name: "FK_TAREFAETIQUETA_ETIQUETA",
                        column: x => x.ETIQUETAID,
                        principalTable: "ETIQUETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAREFAETIQUETA_TAREFA",
                        column: x => x.TAREFAID,
                        principalTable: "TAREFA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAREFA_RESPONSAVELID",
                table: "TAREFA",
                column: "RESPONSAVELID");

            migrationBuilder.CreateIndex(
                name: "IX_TAREFAETIQUETA_ETIQUETAID",
                table: "TAREFAETIQUETA",
                column: "ETIQUETAID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFAENVOLVIDO_USUARIO",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "USUARIOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_ENVOLVIDO",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "TAREFAID",
                principalTable: "TAREFA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFA_USUARIO",
                table: "TAREFA",
                column: "RESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAREFAENVOLVIDO_USUARIO",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_ENVOLVIDO",
                table: "GRUPOTAREFAENVOLVIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_TAREFA_USUARIO",
                table: "TAREFA");

            migrationBuilder.DropTable(
                name: "TAREFAETIQUETA");

            migrationBuilder.DropIndex(
                name: "IX_TAREFA_RESPONSAVELID",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "PRIORIDADE",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "RESPONSAVELID",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "TIPOVINCULO",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "VINCULOID",
                table: "TAREFA");

            migrationBuilder.DropColumn(
                name: "CONCLUIDA",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "DATACONCLUSAO",
                table: "LISTATAREFA");

            migrationBuilder.DropColumn(
                name: "DESCRICAO",
                table: "LISTATAREFA");

            migrationBuilder.RenameColumn(
                name: "ORDEM",
                table: "LISTATAREFA",
                newName: "TIPOVINCULO");

            migrationBuilder.RenameColumn(
                name: "TAREFAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "LISTATAREFAID");

            migrationBuilder.RenameIndex(
                name: "IX_GRUPOTAREFAENVOLVIDO_TAREFAID",
                table: "GRUPOTAREFAENVOLVIDO",
                newName: "IX_GRUPOTAREFAENVOLVIDO_LISTATAREFAID");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "TAREFA",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA",
                table: "TAREFA",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "PRIORIDADE",
                table: "LISTATAREFA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RESPONSAVELID",
                table: "LISTATAREFA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VINCULOID",
                table: "LISTATAREFA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LISTATAREFA_RESPONSAVELID",
                table: "LISTATAREFA",
                column: "RESPONSAVELID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFAENVOLVIDO_LISTATAREFA",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "LISTATAREFAID",
                principalTable: "LISTATAREFA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TAREFAENVOLVIDO_USUARIOS",
                table: "GRUPOTAREFAENVOLVIDO",
                column: "USUARIOID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LISTATAREFA_USUARIO",
                table: "LISTATAREFA",
                column: "RESPONSAVELID",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
