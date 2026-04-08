using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class etiquetacor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TIPOEMAIL",
                table: "PESSOA",
                newName: "TIPOCONTA");

            migrationBuilder.AddColumn<string>(
                name: "COR",
                table: "ETIQUETA",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COR",
                table: "ETIQUETA");

            migrationBuilder.RenameColumn(
                name: "TIPOCONTA",
                table: "PESSOA",
                newName: "TIPOEMAIL");
        }
    }
}
