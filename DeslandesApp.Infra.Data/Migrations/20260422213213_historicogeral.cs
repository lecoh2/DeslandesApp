using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class historicogeral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HISTORICOGERAL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ENTIDADE = table.Column<int>(type: "int", nullable: false),
                    ENTIDADEID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DADOSANTES = table.Column<string>(type: "text", unicode: false, maxLength: 250, nullable: false),
                    DADOSDEPOIS = table.Column<string>(type: "text", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICOGERAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HISTORICOGERAL_USUARIOS_USUARIOID",
                        column: x => x.USUARIOID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICOGERAL_DATAALTERACAO",
                table: "HISTORICOGERAL",
                column: "DATAALTERACAO");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICOGERAL_ENTIDADE",
                table: "HISTORICOGERAL",
                column: "ENTIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICOGERAL_ENTIDADEID",
                table: "HISTORICOGERAL",
                column: "ENTIDADEID");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICOGERAL_USUARIOID",
                table: "HISTORICOGERAL",
                column: "USUARIOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HISTORICOGERAL");
        }
    }
}
