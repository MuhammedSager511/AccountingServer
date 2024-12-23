using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using AccountingServer.Infrastructure.Context;
using GenericRepository;

namespace AccountingServer.Infrastructure.Repositories;
internal sealed class ProductRepository : Repository<Product, CompanyDbContext>, IProductRepository
{
    public ProductRepository(CompanyDbContext context) : base(context)
    {
    }
}
