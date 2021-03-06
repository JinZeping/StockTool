﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockApp.DB;

namespace StockApp.DB.Migrations
{
    [DbContext(typeof(StockDbContext))]
    [Migration("20210101132404_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("StockApp.DB.Models.Exchange", b =>
                {
                    b.Property<int>("ExchangeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ExchangeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExchangeID");

                    b.ToTable("Exchange");
                });

            modelBuilder.Entity("StockApp.DB.Models.Stock", b =>
                {
                    b.Property<int>("StockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ExchangeID")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StockID");

                    b.HasIndex("ExchangeID");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("StockApp.DB.Models.Stock", b =>
                {
                    b.HasOne("StockApp.DB.Models.Exchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exchange");
                });
#pragma warning restore 612, 618
        }
    }
}
