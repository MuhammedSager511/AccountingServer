using AccountingServer.Domain.Repositories;
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
          
        }

    }
}

