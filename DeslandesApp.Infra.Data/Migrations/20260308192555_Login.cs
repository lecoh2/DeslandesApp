using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FAILEDLOGINATTEMPT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Login = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IpAcesso = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UserAgent = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAILEDLOGINATTEMPT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOGINHISTORY",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpAcesso = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UserAgent = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    DataHoraAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sucesso = table.Column<bool>(type: "bit", nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGINHISTORY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOGINHISTORY_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LOGINHISTORY_UsuarioId",
                table: "LOGINHISTORY",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAILEDLOGINATTEMPT");

            migrationBuilder.DropTable(
                name: "LOGINHISTORY");
        }
    }
}
