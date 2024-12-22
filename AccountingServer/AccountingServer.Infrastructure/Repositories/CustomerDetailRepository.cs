using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using AccountingServer.Infrastructure.Context;
using GenericRepository;

namespace AccountingServer.Infrastructure.Repositories;
internal sealed class CustomerDetailRepository : Repository<CustomerDetail, CompanyDbContext>, ICustomerDetailRepository
{
    public CustomerDetailRepository(CompanyDbContext context) : base(context)
    {
    }
}
