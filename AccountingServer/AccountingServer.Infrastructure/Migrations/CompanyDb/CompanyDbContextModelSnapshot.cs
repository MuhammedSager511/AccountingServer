﻿// <auto-generated />
using System;
using AccountingServer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccountingServer.Infrastructure.Migrations.CompanyDb
{
    [DbContext(typeof(CompanyDbContext))]
    partial class CompanyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountingServer.Domain.Entities.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("int");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.BankDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BankDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CashRegisterDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("BankDetails");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.CashRegister", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BalanceAmount")
                        .HasColumnType("money");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("int");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("CashRegisters");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.CashRegisterDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BankDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CashRegisterDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CashRegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CashRegisterId");

                    b.ToTable("CashRegisterDetails");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxDepartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.CustomerDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BankDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CashRegisterDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(7,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Withdrawal")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Withdrawal")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.BankDetail", b =>
                {
                    b.HasOne("AccountingServer.Domain.Entities.Bank", null)
                        .WithMany("Details")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.CashRegisterDetail", b =>
                {
                    b.HasOne("AccountingServer.Domain.Entities.CashRegister", null)
                        .WithMany("Details")
                        .HasForeignKey("CashRegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.CustomerDetail", b =>
                {
                    b.HasOne("AccountingServer.Domain.Entities.Customer", null)
                        .WithMany("Details")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("AccountingServer.Domain.Entities.Product", null)
                        .WithMany("Details")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.Bank", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.CashRegister", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("AccountingServer.Domain.Entities.Product", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
