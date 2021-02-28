using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.DB.Migrations
{
    public partial class AlteColumnName_202101012239 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExchangeNameAbbr",
                table: "Exchange",
                newName: "NameAbbr");

            migrationBuilder.RenameColumn(
                name: "ExchangeName",
                table: "Exchange",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameAbbr",
                table: "Exchange",
                newName: "ExchangeNameAbbr");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Exchange",
                newName: "ExchangeName");
        }
    }
}
