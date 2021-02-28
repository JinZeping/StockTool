using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.DB.Migrations
{
    public partial class AlterTable_YearChangeRateSummary_AddColumn_Percent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Percent",
                table: "YearChangeRateSummary",
                type: "decimal(10,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,4)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Percent",
                table: "YearChangeRateSummary",
                type: "decimal(10,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,4)");
        }
    }
}
