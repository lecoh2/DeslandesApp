using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class umcontrato2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CONTA_RECEBER_CONTRATOID",
                table: "CONTA_RECEBER");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_RECEBER_CONTRATOID",
                table: "CONTA_RECEBER",
                column: "CONTRATOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CONTA_RECEBER_CONTRATOID",
                table: "CONTA_RECEBER");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_RECEBER_CONTRATOID",
                table: "CONTA_RECEBER",
                column: "CONTRATOID",
                unique: true,
                filter: "[CONTRATOID] IS NOT NULL");
        }
    }
}
