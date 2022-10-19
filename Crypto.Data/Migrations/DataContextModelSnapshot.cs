﻿// <auto-generated />
using System;
using Crypto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crypto.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Crypto.Data.Models.CryptoModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("Ath")
                        .HasColumnType("float");

                    b.Property<double?>("Ath_change_percentage")
                        .HasColumnType("float");

                    b.Property<DateTime>("Ath_date")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Current_price")
                        .HasColumnType("float");

                    b.Property<double?>("High_24h")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Last_update")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Low_24h")
                        .HasColumnType("float");

                    b.Property<double?>("Market_cap")
                        .HasColumnType("float");

                    b.Property<double?>("Market_cap_change_24h")
                        .HasColumnType("float");

                    b.Property<double?>("Market_cap_change_percentage_24h")
                        .HasColumnType("float");

                    b.Property<double?>("Market_cap_rank")
                        .HasColumnType("float");

                    b.Property<double?>("Max_supply")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price_change_24h")
                        .HasColumnType("float");

                    b.Property<double?>("Price_change_percentage_24h")
                        .HasColumnType("float");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Total_supply")
                        .HasColumnType("float");

                    b.Property<double?>("Total_volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

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
                    b.Property<Guid>("WatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Coin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WatchId");

                    b.HasIndex("UserId");

                    b.ToTable("WatchList");
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