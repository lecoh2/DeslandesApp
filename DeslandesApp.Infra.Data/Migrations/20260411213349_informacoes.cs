using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class informacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AGENCIA",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "NOMEBANCO",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "NUMEROCONTA",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "PIX",
                table: "INFORMACOESCOMPLEMENTARES");

            migrationBuilder.DropColumn(
                name: "TIPOCONTA",
                table: "INFORMACOESCOMPLEMENTARES");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AGENCIA",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOMEBANCO",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NUMEROCONTA",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PIX",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TIPOCONTA",
                table: "INFORMACOESCOMPLEMENTARES",
                type: "int",
                nullable: true);
        }
    }
}
