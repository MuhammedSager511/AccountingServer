﻿using AccountingServer.Domain.Repositories;
using AccountingServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AccountingServer.Domain.Enums;

namespace AccountingServer.Infrastructure.Context
{
    internal sealed class CompanyDbContext : DbContext, IUnitOfWorkCompany
    {
        private string connectionString = string.Empty;

        public CompanyDbContext(Company company)
        {
            CreateConnectionStringWithCompany(company);
        }
        public CompanyDbContext(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            CreateConnectionString(httpContextAccessor, context);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error configuring DbContext: {ex.Message}");
                throw;
            }
        }



        private void CreateConnectionString(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
           
                if (httpContextAccessor.HttpContext == null) return;
                   

                string? companyId = httpContextAccessor.HttpContext.User.FindFirstValue("CompanyId");
                if (string.IsNullOrEmpty(companyId)) return;

                Company? company = context.Companies.AsNoTracking().FirstOrDefault(c => c.Id == Guid.Parse(companyId));
                if (company == null) return;

                CreateConnectionStringWithCompany(company);
            
             
        }

        private void CreateConnectionStringWithCompany(Company company)
        {
            try
            {
                if (company == null) throw new ArgumentNullException(nameof(company), "Company is null.");

                var builder = new StringBuilder();

                builder.Append($"Server={company.Database.Server}\\mssqllocaldb;");
                builder.Append($"Database={company.Database.DatabaseName};");

                if (string.IsNullOrEmpty(company.Database.UserId))
                {
                    builder.Append("Trusted_Connection=True;");
                }
                else
                {
                    builder.Append("Integrated Security=False;");
                    builder.Append($"User Id={company.Database.UserId};");
                    builder.Append($"Password={company.Database.Password};");
                }

                builder.Append("MultipleActiveResultSets=True;");

                connectionString = builder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error building connection string: {ex.Message}");
                throw;
            }
        }



        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<CashRegisterDetail> CashRegisterDetails { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //CashRegisters
            modelBuilder.Entity<CashRegister>().Property(p => p.DepositAmount).HasColumnType("money");
            modelBuilder.Entity<CashRegister>().Property(p => p.WithdrawalAmount).HasColumnType("money");
            modelBuilder.Entity<CashRegister>().Property(p => p.BalanceAmount).HasColumnType("money");
            modelBuilder.Entity<CashRegister>()
                .Property(p => p.CurrencyType)
                .HasConversion(T => T.Value, value => CurrencyTypeEnum.FromValue(value));
            modelBuilder.Entity<CashRegister>().HasQueryFilter(filter => !filter.IsDeleted);
            modelBuilder.Entity<CashRegister>()
                    .HasMany(p => p.Details)
                    .WithOne()
                    .HasForeignKey(p => p.CashRegisterId);


            //CashRegisterDetails
            modelBuilder.Entity<CashRegisterDetail>().Property(p => p.DepositAmount).HasColumnType("money");
            modelBuilder.Entity<CashRegisterDetail>().Property(p => p.WithdrawalAmount).HasColumnType("money");
            modelBuilder.Entity<CashRegisterDetail>().HasQueryFilter(filter => !filter.IsDeleted);



            // Bank
            modelBuilder.Entity<Bank>().Property(p => p.DepositAmount).HasColumnType("money");
            modelBuilder.Entity<Bank>().Property(p => p.WithdrawalAmount).HasColumnType("money");
            modelBuilder.Entity<Bank>()
                .Property(p => p.CurrencyType)
                .HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));
            modelBuilder.Entity<Bank>().HasQueryFilter(filter => !filter.IsDeleted);
            modelBuilder.Entity<Bank>()
               .HasMany(p => p.Details)
               .WithOne()
               .HasForeignKey(p => p.BankId);
           

            // BankDetail
            modelBuilder.Entity<BankDetail>().Property(p => p.DepositAmount).HasColumnType("money");
            modelBuilder.Entity<BankDetail>().Property(p => p.WithdrawalAmount).HasColumnType("money");


            // Customer
            modelBuilder.Entity<Customer>().Property(p => p.DepositAmount).HasColumnType("money");
            modelBuilder.Entity<Customer>().Property(p => p.WithdrawalAmount).HasColumnType("money");
            modelBuilder.Entity<Customer>().Property(p => p.Type)
                .HasConversion(type => type.Value, value => CustomerTypeEnum.FromValue(value));
            modelBuilder.Entity<Customer>().HasQueryFilter(filter => !filter.IsDeleted);
           
            
            
            ///CustomerDetail
            modelBuilder.Entity<CustomerDetail>().Property(p => p.DepositAmount).HasColumnType("money");
            modelBuilder.Entity<CustomerDetail>().Property(p => p.WithdrawalAmount).HasColumnType("money");
            modelBuilder.Entity<CustomerDetail>().Property(p => p.Type)
               .HasConversion(type => type.Value, value => CustomerDetailTypeEnum.FromValue(value));

            //ProductDetail
            modelBuilder.Entity<ProductDetail>().Property(p => p.Deposit).HasColumnType("decimal(7,2)");
            modelBuilder.Entity<ProductDetail>().Property(p => p.Withdrawal).HasColumnType("decimal(7,2)");
            modelBuilder.Entity<ProductDetail>().Property(p => p.Price).HasColumnType("money");
          
            
            // Product
            modelBuilder.Entity<Product>().HasQueryFilter(filter => !filter.IsDeleted);
            modelBuilder.Entity<Product>().Property(p => p.Deposit).HasColumnType("decimal(7,2)");
            modelBuilder.Entity<Product>().Property(p => p.Withdrawal).HasColumnType("decimal(7,2)");




           // Invoice
            modelBuilder.Entity<Invoice>().Property(p => p.Amount).HasColumnType("money");
            modelBuilder.Entity<Invoice>().Property(p => p.Type)
                .HasConversion(type => type.Value, value => InvoiceTypeEnum.FromValue(value));
            modelBuilder.Entity<Invoice>().HasQueryFilter(filter => !filter.IsDeleted);
            modelBuilder.Entity<Invoice>().HasQueryFilter(filter => !filter.Customer!.IsDeleted);
            


            //InvoiceDetail
            modelBuilder.Entity<InvoiceDetail>().Property(p => p.Quantity).HasColumnType("decimal(7,2)");
            modelBuilder.Entity<InvoiceDetail>().Property(p => p.Price).HasColumnType("money");
            modelBuilder.Entity<InvoiceDetail>().HasQueryFilter(filter => !filter.Product!.IsDeleted);
            

        }

    }
}

