using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslandesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class notificao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "REFERENCIAID",
                table: "NOTIFICACAO",
                newName: "ENTIDADEID");

            migrationBuilder.AlterColumn<int>(
                name: "TIPO",
                table: "NOTIFICACAO",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "LINK",
                table: "NOTIFICACAO",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LINK",
                table: "NOTIFICACAO");

            migrationBuilder.RenameColumn(
                name: "ENTIDADEID",
                table: "NOTIFICACAO",
                newName: "REFERENCIAID");

            migrationBuilder.AlterColumn<string>(
                name: "TIPO",
                table: "NOTIFICACAO",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);
        }
    }
}
