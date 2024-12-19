using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using AccountingServer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AccountingServer.Infrastructure.Services;
internal sealed class CompanyService : ICompanyService
{
    public void MigrateAll(List<Company> companies)
    {
        foreach (var company in companies)
        {
            CompanyDbContext context = new(company);

            context.Database.Migrate();
        }
    }
}
