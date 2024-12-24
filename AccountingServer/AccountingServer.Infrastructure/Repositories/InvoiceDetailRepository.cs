using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using AccountingServer.Infrastructure.Context;
using GenericRepository;

namespace AccountingServer.Infrastructure.Repositories;

internal sealed class InvoiceDetailRepository : Repository<InvoiceDetail, CompanyDbContext>, IInvoiceDetailRepository
{
    public InvoiceDetailRepository(CompanyDbContext context) : base(context)
    {
    }
}