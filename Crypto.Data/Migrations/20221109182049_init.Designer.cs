﻿// <auto-generated />
using System;
using Crypto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crypto.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221109182049_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Crypto.Data.Models.CryptoDetails", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("_market_Dataid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("asset_platform_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("block_time_in_minutes")
                        .HasColumnType("datetime2");

                    b.Property<string>("hashing_algorithm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("market_cap_rank")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("_market_Dataid");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("Crypto.Data.Models.CryptoDetails+market_data", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("current_price")
                        .HasColumnType("int");

                    b.Property<int?>("high_24h")
                        .HasColumnType("int");

                    b.Property<int?>("low_24h")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("market_data");
                });

            modelBuilder.Entity("Crypto.Data.Models.CryptoModel", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ath")
                        .HasColumnType("float");

                    b.Property<double>("ath_change_percentage")
                        .HasColumnType("float");

                    b.Property<DateTime>("ath_date")
                        .HasColumnType("datetime2");

                    b.Property<double>("current_price")
                        .HasColumnType("float");

                    b.Property<double>("high_24h")
                        .HasColumnType("float");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("last_update")
                        .HasColumnType("datetime2");

                    b.Property<double>("low_24h")
                        .HasColumnType("float");

                    b.Property<double>("market_cap")
                        .HasColumnType("float");

                    b.Property<double>("market_cap_change_24h")
                        .HasColumnType("float");

                    b.Property<double>("market_cap_change_percentage_24h")
                        .HasColumnType("float");

                    b.Property<double>("market_cap_rank")
                        .HasColumnType("float");

                    b.Property<double>("max_supply")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price_change_24h")
                        .HasColumnType("float");

                    b.Property<double>("price_change_percentage_24h")
                        .HasColumnType("float");

                    b.Property<string>("symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("total_supply")
                        .HasColumnType("float");

                    b.Property<double>("total_volume")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Crypto");
                });

            modelBuilder.Entity("Crypto.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Crypto.Data.Models.WatchList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Coin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WatchList");
                });

            modelBuilder.Entity("Crypto.Data.Models.CryptoDetails", b =>
                {
                    b.HasOne("Crypto.Data.Models.CryptoDetails+market_data", "_market_Data")
                        .WithMany()
                        .HasForeignKey("_market_Dataid");

                    b.Navigation("_market_Data");
                });

            modelBuilder.Entity("Crypto.Data.Models.WatchList", b =>
                {
                    b.HasOne("Crypto.Data.Models.User", null)
                        .WithMany("WatchList")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Crypto.Data.Models.User", b =>
                {
                    b.Navigation("WatchList");
                });
#pragma warning restore 612, 618
        }
    }
}