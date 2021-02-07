using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.Migrations
{
    public partial class AddTable_MonthSeasonYearTradeRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthTradeRecord",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Begin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    End = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Max = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Min = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Change = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradeHand = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amplitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TurnoverRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthTradeRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MonthTradeRecord_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeasonTradeRecord",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Begin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    End = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Max = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Min = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Change = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradeHand = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amplitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TurnoverRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonTradeRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SeasonTradeRecord_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearTradeRecord",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Begin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    End = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Max = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Min = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Change = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradeHand = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amplitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TurnoverRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StockID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearTradeRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_YearTradeRecord_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthTradeRecord_StockID",
                table: "MonthTradeRecord",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonTradeRecord_StockID",
                table: "SeasonTradeRecord",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_YearTradeRecord_StockID",
                table: "YearTradeRecord",
                column: "StockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthTradeRecord");

            migrationBuilder.DropTable(
                name: "SeasonTradeRecord");

            migrationBuilder.DropTable(
                name: "YearTradeRecord");
        }
    }
}
