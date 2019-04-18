using Microsoft.EntityFrameworkCore.Migrations;

namespace PrototipoVendas.Infra.Data.Migrations
{
    public partial class Produto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtensaoFoto",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "NomeFoto",
                table: "Produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtensaoFoto",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFoto",
                table: "Produto",
                nullable: true);
        }
    }
}
