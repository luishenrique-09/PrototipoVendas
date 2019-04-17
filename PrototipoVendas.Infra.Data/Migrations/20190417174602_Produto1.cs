using Microsoft.EntityFrameworkCore.Migrations;

namespace PrototipoVendas.Infra.Data.Migrations
{
    public partial class Produto1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "ExtensaoFoto",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFoto",
                table: "Produto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtensaoFoto",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "NomeFoto",
                table: "Produto");

            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
