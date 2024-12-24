using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using AccountingServer.Infrastructure.Context;
using GenericRepository;

namespace AccountingServer.Infrastructure.Repositories;
internal sealed class InvoiceRepository : Repository<Invoice, CompanyDbContext>, IInvoiceRepository
{
    public InvoiceRepository(CompanyDbContext context) : base(context)
    {
    }
}
