using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using AccountingServer.Infrastructure.Context;
using GenericRepository;

namespace AccountingServer.Infrastructure.Repositories;
internal sealed class CustomerRepository : Repository<Customer, CompanyDbContext>, ICustomerRepository
{
    public CustomerRepository(CompanyDbContext context) : base(context)
    {
    }
}
