using AccountingServer.Domain.Entities;

namespace AccountingServer.Application.Services;
public interface ICompanyService
{
    void MigrateAll(List<Company> companies);
}
