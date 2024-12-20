using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using AccountingServer.Infrastructure.Context;
using GenericRepository;

namespace AccountingServer.Infrastructure.Repositories;
internal sealed class CashRegisterDetailRepository : Repository<CashRegisterDetail, CompanyDbContext>, ICashRegisterDetailRepository
{
    public CashRegisterDetailRepository(CompanyDbContext context) : base(context)
    {
    }
}
