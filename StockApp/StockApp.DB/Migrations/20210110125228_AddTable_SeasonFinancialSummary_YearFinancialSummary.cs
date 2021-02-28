using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.DB.Migrations
{
    public partial class AddTable_SeasonFinancialSummary_YearFinancialSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeasonFinancialSummary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    PrimaryEarningsPerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetAssetsPerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingNetCashFlowPerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MainBusinessIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MainBusinessProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BusinessProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvestmentReturn = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetNonOperatingIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetProfitAfterDeductingNonRecurring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashFlowFromOperatingActivities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetIncreaseInCashAndEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OwnerEquity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WeightedReturnOnEquity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonFinancialSummary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SeasonFinancialSummary_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearFinancialSummary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    PrimaryEarningsPerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetAssetsPerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingNetCashFlowPerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MainBusinessIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MainBusinessProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BusinessProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvestmentReturn = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetNonOperatingIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetProfitAfterDeductingNonRecurring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashFlowFromOperatingActivities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetIncreaseInCashAndEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OwnerEquity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WeightedReturnOnEquity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearFinancialSummary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_YearFinancialSummary_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeasonFinancialSummary_StockID",
                table: "SeasonFinancialSummary",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_YearFinancialSummary_StockID",
                table: "YearFinancialSummary",
                column: "StockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeasonFinancialSummary");

            migrationBuilder.DropTable(
                name: "YearFinancialSummary");
        }
    }
}
