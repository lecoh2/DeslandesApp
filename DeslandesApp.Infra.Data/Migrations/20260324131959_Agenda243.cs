using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Agenda243 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "TAREFA",
                newName: "STATUSKANBAN");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "EVENTO",
                newName: "STATUSKANBAN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "STATUSKANBAN",
                table: "TAREFA",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "STATUSKANBAN",
                table: "EVENTO",
                newName: "STATUS");
        }
    }
}
