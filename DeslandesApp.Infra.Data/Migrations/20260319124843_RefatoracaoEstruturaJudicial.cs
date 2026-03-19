using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefatoracaoEstruturaJudicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FORO_VARA_VARAID",
                table: "FORO");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_FORO_FOROID",
                table: "PROCESSOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_FORO_FOROID1",
                table: "PROCESSOS");

            migrationBuilder.DropForeignKey(
                name: "FK_VARA_JUIZO_JUIZOID",
                table: "VARA");

            migrationBuilder.DropTable(
                name: "JUIZO");

            migrationBuilder.DropIndex(
                name: "IX_PROCESSOS_FOROID",
                table: "PROCESSOS");

            migrationBuilder.DropIndex(
                name: "IX_PROCESSOS_FOROID1",
                table: "PROCESSOS");

            migrationBuilder.DropIndex(
                name: "IX_FORO_VARAID",
                table: "FORO");

            migrationBuilder.DropColumn(
                name: "FOROID",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "FOROID1",
                table: "PROCESSOS");

            migrationBuilder.DropColumn(
                name: "VARAID",
                table: "FORO");

            migrationBuilder.RenameColumn(
                name: "JUIZOID",
                table: "VARA",
                newName: "FOROID");

            migrationBuilder.RenameIndex(
                name: "IX_VARA_JUIZOID",
                table: "VARA",
                newName: "IX_VARA_FOROID");

            migrationBuilder.RenameColumn(
                name: "RESPONSAVAEL",
                table: "PROCESSOS",
                newName: "RESPONSAVEL");

            migrationBuilder.AlterColumn<string>(
                name: "NOMEVARA",
                table: "VARA",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NUMERO",
                table: "VARA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TIPO",
                table: "VARA",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "VARAID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VARA_NUMERO_TIPO_FOROID",
                table: "VARA",
                columns: new[] { "NUMERO", "TIPO", "FOROID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_VARAID",
                table: "PROCESSOS",
                column: "VARAID");

            migrationBuilder.CreateIndex(
                name: "IX_FORO_NOMEFORO",
                table: "FORO",
                column: "NOMEFORO",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_VARA_VARAID",
                table: "PROCESSOS",
                column: "VARAID",
                principalTable: "VARA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VARA_FORO_FOROID",
                table: "VARA",
                column: "FOROID",
                principalTable: "FORO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROCESSOS_VARA_VARAID",
                table: "PROCESSOS");

            migrationBuilder.DropForeignKey(
                name: "FK_VARA_FORO_FOROID",
                table: "VARA");

            migrationBuilder.DropIndex(
                name: "IX_VARA_NUMERO_TIPO_FOROID",
                table: "VARA");

            migrationBuilder.DropIndex(
                name: "IX_PROCESSOS_VARAID",
                table: "PROCESSOS");

            migrationBuilder.DropIndex(
                name: "IX_FORO_NOMEFORO",
                table: "FORO");

            migrationBuilder.DropColumn(
                name: "NUMERO",
                table: "VARA");

            migrationBuilder.DropColumn(
                name: "TIPO",
                table: "VARA");

            migrationBuilder.DropColumn(
                name: "VARAID",
                table: "PROCESSOS");

            migrationBuilder.RenameColumn(
                name: "FOROID",
                table: "VARA",
                newName: "JUIZOID");

            migrationBuilder.RenameIndex(
                name: "IX_VARA_FOROID",
                table: "VARA",
                newName: "IX_VARA_JUIZOID");

            migrationBuilder.RenameColumn(
                name: "RESPONSAVEL",
                table: "PROCESSOS",
                newName: "RESPONSAVAEL");

            migrationBuilder.AlterColumn<string>(
                name: "NOMEVARA",
                table: "VARA",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AddColumn<Guid>(
                name: "FOROID",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FOROID1",
                table: "PROCESSOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VARAID",
                table: "FORO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "JUIZO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEJUIZO = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JUIZO", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_FOROID",
                table: "PROCESSOS",
                column: "FOROID");

            migrationBuilder.CreateIndex(
                name: "IX_PROCESSOS_FOROID1",
                table: "PROCESSOS",
                column: "FOROID1");

            migrationBuilder.CreateIndex(
                name: "IX_FORO_VARAID",
                table: "FORO",
                column: "VARAID");

            migrationBuilder.AddForeignKey(
                name: "FK_FORO_VARA_VARAID",
                table: "FORO",
                column: "VARAID",
                principalTable: "VARA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_FORO_FOROID",
                table: "PROCESSOS",
                column: "FOROID",
                principalTable: "FORO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROCESSOS_FORO_FOROID1",
                table: "PROCESSOS",
                column: "FOROID1",
                principalTable: "FORO",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_VARA_JUIZO_JUIZOID",
                table: "VARA",
                column: "JUIZOID",
                principalTable: "JUIZO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
