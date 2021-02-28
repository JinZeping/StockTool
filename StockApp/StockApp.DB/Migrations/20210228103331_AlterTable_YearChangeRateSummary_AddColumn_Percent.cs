using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.DB.Migrations
{
    public partial class AlterTable_YearChangeRateSummary_AddColumn_Percent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Percent",
                table: "YearChangeRateSummary",
                type: "decimal(10,4)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent",
                table: "YearChangeRateSummary");
        }
    }
}
