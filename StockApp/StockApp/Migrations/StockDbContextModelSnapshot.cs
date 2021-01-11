﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockApp.DB;

namespace StockApp.Migrations
{
    [DbContext(typeof(StockDbContext))]
    partial class StockDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("StockApp.DB.Models.SeasonFinancialSummary", b =>
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

            modelBuilder.Entity("StockApp.DB.Models.YearFinancialSummary", b =>
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
