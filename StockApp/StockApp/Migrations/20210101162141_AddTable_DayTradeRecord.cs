using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApp.Migrations
{
    public partial class AddTable_DayTradeRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ListingDate",
                table: "Stock",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Board",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameAbbr",
                table: "Exchange",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exchange",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DayTradeRecord",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Begin = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    End = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Max = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Min = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ChangeRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TradeHand = table.Column<int>(type: "int", nullable: false),
                    TradeAmount = table.Column<int>(type: "int", nullable: false),
                    Amplitude = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TurnoverRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StockID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTradeRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DayTradeRecord_Stock_StockID",
                        column: x => x.StockID,
                        principalTable: "Stock",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayTradeRecord_StockID",
                table: "DayTradeRecord",
                column: "StockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayTradeRecord");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ListingDate",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Board",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameAbbr",
                table: "Exchange",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exchange",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
