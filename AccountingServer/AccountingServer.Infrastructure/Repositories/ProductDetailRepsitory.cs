using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using AccountingServer.Infrastructure.Context;
using GenericRepository;

namespace AccountingServer.Infrastructure.Repositories;
internal sealed class ProductDetailRepsitory : Repository<ProductDetail, CompanyDbContext>, IProductDetailRepository
{
    public ProductDetailRepsitory(CompanyDbContext context) : base(context)
    {
    }
}
