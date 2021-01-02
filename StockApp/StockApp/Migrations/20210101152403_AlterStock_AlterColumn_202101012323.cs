using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.Migrations
{
    public partial class AlterStock_AlterColumn_202101012323 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockID",
                table: "Stock",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ExchangeID",
                table: "Exchange",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Stock",
                newName: "StockID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Exchange",
                newName: "ExchangeID");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
