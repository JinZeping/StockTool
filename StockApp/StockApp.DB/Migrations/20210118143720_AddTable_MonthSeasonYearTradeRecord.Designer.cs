﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockApp.DB;

namespace StockApp.DB.Migrations
{
    [DbContext(typeof(StockDbContext))]
    [Migration("20210118143720_AddTable_MonthSeasonYearTradeRecord")]
    partial class AddTable_MonthSeasonYearTradeRecord
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("StockApp.DB.Models.CrawlTask", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("StockID")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StockID");

                    b.ToTable("CrawlTask");
                });

            modelBuilder.Entity("StockApp.DB.Models.DayTradeRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("Amplitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Begin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Change")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ChangeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("End")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Max")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Min")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TradeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradeHand")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TurnoverRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("StockID");

                    b.ToTable("DayTradeRecord");
                });

            modelBuilder.Entity("StockApp.DB.Models.Exchange", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAbbr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Exchange");
                });

            modelBuilder.Entity("StockApp.DB.Models.MonthTradeRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("Amplitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Begin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Change")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ChangeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("End")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Max")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Min")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TradeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradeHand")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TurnoverRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("StockID");

                    b.ToTable("MonthTradeRecord");
                });

            modelBuilder.Entity("StockApp.DB.Models.SeasonFinancialBrief", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("BasicEarningPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BeginBalanceOfCashAndCashEquivalents")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("EndBalanceOfCashAndCashEquivalents")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("IncomeTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Inventory")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetCashFlowFromFinancing")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetCashFlowFromInvestment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetCashFlowFromOperating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetFixedAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetIncreaseInCashAndCashEquivalents")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingCosts")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Receivables")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalCurrentAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalCurrentLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalNonCurrentLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalOwnerEquity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalProfit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("StockID");

                    b.ToTable("SeasonFinancialBrief");
                });

            modelBuilder.Entity("StockApp.DB.Models.SeasonFinancialSummary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("BusinessProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CurrentAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CurrentLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("InvestmentReturn")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MainBusinessIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MainBusinessProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetAssetsPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetCashFlowFromOperatingActivities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetIncreaseInCashAndEquivalents")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetNonOperatingIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetProfitAfterDeductingNonRecurring")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingNetCashFlowPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OwnerEquity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PrimaryEarningsPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("WeightedReturnOnEquity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("StockID");

                    b.ToTable("SeasonFinancialSummary");
                });

            modelBuilder.Entity("StockApp.DB.Models.SeasonTradeRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("Amplitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Begin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Change")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ChangeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("End")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Max")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Min")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TradeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradeHand")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TurnoverRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("StockID");

                    b.ToTable("SeasonTradeRecord");
                });

            modelBuilder.Entity("StockApp.DB.Models.Stock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Board")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExchangeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ListingDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ExchangeID");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.YearFinancialBrief", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("BasicEarningPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BeginBalanceOfCashAndCashEquivalents")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("EndBalanceOfCashAndCashEquivalents")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("IncomeTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Inventory")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetCashFlowFromFinancing")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetCashFlowFromInvestment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetCashFlowFromOperating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetFixedAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetIncreaseInCashAndCashEquivalents")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingCosts")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Receivables")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalCurrentAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalCurrentLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalNonCurrentLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalOwnerEquity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalProfit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("StockID");

                    b.ToTable("YearFinancialBrief");
                });

            modelBuilder.Entity("StockApp.DB.Models.YearFinancialSummary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("BusinessProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CurrentAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CurrentLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("InvestmentReturn")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MainBusinessIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MainBusinessProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetAssetsPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetCashFlowFromOperatingActivities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetIncreaseInCashAndEquivalents")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetNonOperatingIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NetProfitAfterDeductingNonRecurring")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OperatingNetCashFlowPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OwnerEquity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PrimaryEarningsPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("WeightedReturnOnEquity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("StockID");

                    b.ToTable("YearFinancialSummary");
                });

            modelBuilder.Entity("StockApp.DB.Models.YearTradeRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("Amplitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Begin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Change")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ChangeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal?>("End")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Max")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Min")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TradeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradeHand")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TurnoverRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("StockID");

                    b.ToTable("YearTradeRecord");
                });

            modelBuilder.Entity("StockApp.DB.Models.CrawlTask", b =>
                {
                    b.HasOne("StockApp.DB.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.DayTradeRecord", b =>
                {
                    b.HasOne("StockApp.DB.Models.Stock", "Stock")
                        .WithMany("DayTradeRecords")
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.MonthTradeRecord", b =>
                {
                    b.HasOne("StockApp.DB.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.SeasonFinancialBrief", b =>
                {
                    b.HasOne("StockApp.DB.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.SeasonFinancialSummary", b =>
                {
                    b.HasOne("StockApp.DB.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.SeasonTradeRecord", b =>
                {
                    b.HasOne("StockApp.DB.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.Stock", b =>
                {
                    b.HasOne("StockApp.DB.Models.Exchange", "Exchange")
                        .WithMany("Stocks")
                        .HasForeignKey("ExchangeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exchange");
                });

            modelBuilder.Entity("StockApp.DB.Models.YearFinancialBrief", b =>
                {
                    b.HasOne("StockApp.DB.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.YearFinancialSummary", b =>
                {
                    b.HasOne("StockApp.DB.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.YearTradeRecord", b =>
                {
                    b.HasOne("StockApp.DB.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.Exchange", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("StockApp.DB.Models.Stock", b =>
                {
                    b.Navigation("DayTradeRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
