using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateWebJurSincronizacaoLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WEBJURSINCRONIZACAOLOG",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATAEXECUCAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TOTALRECEBIDOS = table.Column<int>(type: "int", nullable: false),
                    TOTALIMPORTADOS = table.Column<int>(type: "int", nullable: false),
                    TOTALFALHAS = table.Column<int>(type: "int", nullable: false),
                    STATUS = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MENSAGEMERRO = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WEBJURSINCRONIZACAOLOG", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WEBJURSINCRONIZACAOLOG");
        }
    }
}
