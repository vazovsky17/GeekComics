﻿// <auto-generated />
using System;
using GeekComics.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekComics.EntityFramework.Migrations
{
    [DbContext(typeof(GeekComicsDbContext))]
    [Migration("20220623003457_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GeekComics.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountHolderId")
                        .HasColumnType("int");

                    b.Property<string>("AddressDelivery")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<double>("BonusCount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountHolderId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.BonusAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("BonusCount")
                        .HasColumnType("float");

                    b.Property<bool>("IsAccrual")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("BonusHistory");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<double>("DateEmployment")
                        .HasColumnType("float");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("BonusActionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDelivered")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BonusActionId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StockAvailabilityCount")
                        .HasColumnType("int");

                    b.Property<int>("StoreAvailabilityCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.ProductInBusket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Busket");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.Account", b =>
                {
                    b.HasOne("GeekComics.Domain.Models.User", "AccountHolder")
                        .WithMany()
                        .HasForeignKey("AccountHolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountHolder");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.Employee", b =>
                {
                    b.HasOne("GeekComics.Domain.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.Order", b =>
                {
                    b.HasOne("GeekComics.Domain.Models.Account", null)
                        .WithMany("Orders")
                        .HasForeignKey("AccountId");

                    b.HasOne("GeekComics.Domain.Models.BonusAction", "BonusAction")
                        .WithMany()
                        .HasForeignKey("BonusActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BonusAction");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.ProductInBusket", b =>
                {
                    b.HasOne("GeekComics.Domain.Models.Account", null)
                        .WithMany("Busket")
                        .HasForeignKey("AccountId");

                    b.HasOne("GeekComics.Domain.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("GeekComics.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.Account", b =>
                {
                    b.Navigation("Busket");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GeekComics.Domain.Models.Order", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
