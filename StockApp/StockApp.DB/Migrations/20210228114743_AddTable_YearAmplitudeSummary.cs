using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.DB.Migrations
{
    public partial class AddTable_YearAmplitudeSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YearAmplitudeSummary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    LowLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HighLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Step = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(10,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearAmplitudeSummary", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearAmplitudeSummary");
        }
    }
}
