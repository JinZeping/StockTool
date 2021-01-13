using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.Migrations
{
    public partial class AddTable_SeasonFinancialBrief_YearFinancialBrief : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeasonFinancialBrief",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    OperatingIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IncomeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BasicEarningPerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Receivables = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inventory = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCurrentAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetFixedAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalNonCurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalOwnerEquity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BeginBalanceOfCashAndCashEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EndBalanceOfCashAndCashEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashFlowFromOperating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashFlowFromInvestment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashFlowFromFinancing = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetIncreaseInCashAndCashEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonFinancialBrief", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SeasonFinancialBrief_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearFinancialBrief",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    OperatingIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IncomeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BasicEarningPerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Receivables = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inventory = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCurrentAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetFixedAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalNonCurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalOwnerEquity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BeginBalanceOfCashAndCashEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EndBalanceOfCashAndCashEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashFlowFromOperating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashFlowFromInvestment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetCashFlowFromFinancing = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetIncreaseInCashAndCashEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearFinancialBrief", x => x.ID);
                    table.ForeignKey(
                        name: "FK_YearFinancialBrief_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeasonFinancialBrief_StockID",
                table: "SeasonFinancialBrief",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_YearFinancialBrief_StockID",
                table: "YearFinancialBrief",
                column: "StockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeasonFinancialBrief");

            migrationBuilder.DropTable(
                name: "YearFinancialBrief");
        }
    }
}
