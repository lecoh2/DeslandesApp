using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialEtiqueta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEtiqueta",
                table: "PESSOA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdEtiqueta",
                table: "PESSOA",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
