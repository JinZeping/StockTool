using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.DB.Migrations
{
    public partial class AlteTable_YearChangeRateSummary_ChangeColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndRange",
                table: "YearChangeRateSummary",
                newName: "Step");

            migrationBuilder.RenameColumn(
                name: "BeginRange",
                table: "YearChangeRateSummary",
                newName: "LowLimit");

            migrationBuilder.AddColumn<decimal>(
                name: "HighLimit",
                table: "YearChangeRateSummary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighLimit",
                table: "YearChangeRateSummary");

            migrationBuilder.RenameColumn(
                name: "Step",
                table: "YearChangeRateSummary",
                newName: "EndRange");

            migrationBuilder.RenameColumn(
                name: "LowLimit",
                table: "YearChangeRateSummary",
                newName: "BeginRange");
        }
    }
}
